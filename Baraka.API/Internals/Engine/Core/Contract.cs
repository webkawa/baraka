namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Text;

    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Microsoft.Extensions.Logging;
    using NHibernate;

    /// <summary>
    ///     Statut d'un contrat.
    /// </summary>
    internal enum ContractStatus
    {
        /// <summary>
        ///     Statut initial.
        ///     Statut affecté à l'initialisation du contrat.
        /// </summary>
        INITIAL,

        /// <summary>
        ///     Injecté.
        ///     Statut affecté dès l'injection du contrat dans un gestionnaire
        ///     adapté.
        /// </summary>
        INJECTED,

        /// <summary>
        ///     En cours.
        ///     Statut affecté dès lors que le contrat est activement pris en
        ///     charge par l'application.
        /// </summary>
        RUNNING,

        /// <summary>
        ///     En attente.
        ///     Statut affecté quand le contrat attend l'exécution d'un ou plusieurs
        ///     sous-contrats.
        /// </summary>
        WAITING,

        /// <summary>
        ///     En pause.
        ///     Statut affecté dès mise en attente du contrat par l'application.
        /// </summary>
        PAUSED,

        /// <summary>
        ///     Finalisé.
        ///     Statut affecté dès la finalisation du contrat.
        /// </summary>
        FINALIZED
    }

    /// <summary>
    ///     Résultat de l'exécution.
    /// </summary>
    internal enum ContractResult
    {
        /// <summary>
        ///     Succès.
        /// </summary>
        SUCCESS,

        /// <summary>
        ///     Echec.
        /// </summary>
        FAILURE,

        /// <summary>
        ///     Annulation.
        /// </summary>
        CANCELED,

        /// <summary>
        ///     Erreur.
        /// </summary>
        ERROR
    }

    /// <summary>
    ///     Priorité du contrat.
    /// </summary>
    internal enum ContractPriority
    {
        /// <summary>
        ///     Exécution immédiate.
        /// </summary>
        IMMEDIATE,

        /// <summary>
        ///     Exécution dès disponibilité.
        /// </summary>
        PLANIFIED,

        /// <summary>
        ///     Exécution au plus tard.
        /// </summary>
        LAZY
    }

    /// <summary>
    ///     Interface des contrats.
    /// </summary>
    internal interface IContract
    {
        /// <summary>
        ///     Moteur.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        ///     Transaction de rattachement.
        /// </summary>
        ITransaction Transaction { get; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        ///     Statut courant.
        /// </summary>
        ContractStatus CurrentStatus { get; }

        /// <summary>
        ///     Au changement du statut.
        /// </summary>
        IObservable<ContractStatus> OnStatusChange { get; }

        /// <summary>
        ///     Au lancement.
        /// </summary>
        IObservable<ContractStatus> OnRun { get; }

        /// <summary>
        ///     A l'émission du résultat.
        /// </summary>
        IObservable<ContractResult> OnResultChange { get; }

        /// <summary>
        ///     Au succès.
        /// </summary>
        IObservable<ContractResult> OnSuccess { get; }

        /// <summary>
        ///     A l'échec.
        /// </summary>
        IObservable<ContractResult> OnFailure { get; }

        /// <summary>
        ///     A l'annulation.
        /// </summary>
        IObservable<ContractResult> OnCancel { get; }

        /// <summary>
        ///     A l'erreur.
        /// </summary>
        IObservable<ContractResult> OnError { get; }

        /// <summary>
        ///     A la finalisation.
        /// </summary>
        IObservable<ContractResult> OnFinalized { get; }

        /// <summary>
        ///     Passe le contrat au statut intégré.
        /// </summary>
        void Integrate();

        /// <summary>
        ///     Passe le contrat au statut actif.
        /// </summary>
        void Run();

        /// <summary>
        ///     Place le contrat en attente d'un ensemble de contrats tiers.
        /// </summary>
        /// <param name="contracts">Contrats attendus.</param>
        /// <returns>Liste des résultats.</returns>
        IObservable<IEnumerable<ContractResult>> Wait(params IContract[] contracts);

        /// <summary>
        ///     Passe le contrat au statut pause.
        /// </summary>
        void Pause();

        /// <summary>
        ///     Passe le contrat au statut finalisé.
        /// </summary>
        /// <param name="result">Résultat affecté.</param>
        void Finalize(ContractResult result);
    }

    /// <summary>
    ///     Contrat.
    ///     Objet descriptif, au niveau moteur, d'une tâche atomique à accomplir dans
    ///     le cadre d'un processus plus large.
    /// </summary>
    internal abstract class Contract : IContract
    {
        /// <summary>
        ///     Constructeur sans origine.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public Contract(IEngine engine)
        {
            Engine = engine;
            Status = new BehaviorSubject<ContractStatus>(ContractStatus.INITIAL);
            Result = new AsyncSubject<ContractResult>();

            Transaction = null;
            Priority = ContractPriority.PLANIFIED;
        }

        /// <summary>
        ///     Transaction de rattachement.
        /// </summary>
        public ITransaction Transaction { get; set; }

        /// <summary>
        ///     Priorité.
        /// </summary>
        public ContractPriority Priority { get; set; }

        /// <summary>
        ///     Moteur applicatif.
        /// </summary>
        public IEngine Engine { get; private set; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        public ILogger Logger => Engine.Logger;

        /// <summary>
        ///     Statut courant.
        /// </summary>
        public ContractStatus CurrentStatus => Status.Value;

        /// <summary>
        ///     Au changement du statut.
        /// </summary>
        public IObservable<ContractStatus> OnStatusChange => Status.Distinct();

        /// <summary>
        ///     Au lancement.
        /// </summary>
        public IObservable<ContractStatus> OnRun => Status
            .Where(e => e == ContractStatus.RUNNING)
            .Take(1);

        /// <summary>
        ///     A la finalisation.
        /// </summary>
        public IObservable<ContractResult> OnFinalized => Status
            .Where(e => e == ContractStatus.FINALIZED)
            .CombineLatest(Result, (status, result) => result)
            .Take(1);

        /// <summary>
        ///     A l'émission du résultat.
        /// </summary>
        public IObservable<ContractResult> OnResultChange => Result;

        /// <summary>
        ///     Au succès.
        /// </summary>
        public IObservable<ContractResult> OnSuccess => Result
            .Where(e => e == ContractResult.SUCCESS)
            .Take(1);

        /// <summary>
        ///     A l'échec.
        /// </summary>
        public IObservable<ContractResult> OnFailure => Result
            .Where(e => e == ContractResult.FAILURE)
            .Take(1);

        /// <summary>
        ///     A l'annulation.
        /// </summary>
        public IObservable<ContractResult> OnCancel => Result
            .Where(e => e == ContractResult.CANCELED)
            .Take(1);

        /// <summary>
        ///     A l'erreur.
        /// </summary>
        public IObservable<ContractResult> OnError => Result
            .Where(e => e == ContractResult.ERROR)
            .Take(1);
        
        /// <summary>
        ///     Statut.
        /// </summary>
        private BehaviorSubject<ContractStatus> Status { get; set; }

        /// <summary>
        ///     Résultat.
        /// </summary>
        private AsyncSubject<ContractResult> Result { get; set; }
        
        /// <summary>
        ///     <see cref="IContract.Integrate()" />
        /// </summary>
        public void Integrate()
        {
            SwitchStatus(ContractStatus.INJECTED);
        }

        /// <summary>
        ///     <see cref="IContract.Run()" />
        /// </summary>
        public void Run()
        {
            SwitchStatus(ContractStatus.RUNNING);
        }

        /// <summary>
        ///     <see cref="IContract.Wait(IContract[])" />
        /// </summary>
        public IObservable<IEnumerable<ContractResult>> Wait(params IContract[] contracts)
        {
            // Vérification de non-redondance
            // Attention : si supprimé, nécessite la mise en oeuvre d'un contrôle de nature similaire !
            if (contracts.Any(e => e.CurrentStatus != ContractStatus.INITIAL))
            {
                throw new EngineException("Wait dependencies can only be defined to contracts at initial status");
            }

            // Mise en attente effective
            SwitchStatus(ContractStatus.WAITING);
            return contracts
                .Select(e => e.OnFinalized)
                .Zip()
                .Select((results) =>
                {
                    SwitchStatus(ContractStatus.RUNNING);
                    return results;
                })
                .Take(1);
        }

        /// <summary>
        ///     <see cref="IContract.Pause()" />
        /// </summary>
        public void Pause()
        {
            SwitchStatus(ContractStatus.PAUSED);
        }

        /// <summary>
        ///     <see cref="IContract.Finalize(ContractResult)" />
        /// </summary>
        public void Finalize(ContractResult result)
        {
            SwitchStatus(ContractStatus.FINALIZED);
            Status.Dispose();

            Result.OnNext(result);
            Result.Dispose();
        }

        /// <summary>
        ///     Réalise la mise à jour du statut.
        /// </summary>
        /// <param name="to">Statut affecté.</param>
        private void SwitchStatus(ContractStatus to)
        {
            bool valid = true;
            switch (to)
            {
                case ContractStatus.INITIAL:
                    valid = false;
                    break;

                case ContractStatus.INJECTED:
                    valid = CurrentStatus == ContractStatus.INITIAL;
                    break;

                case ContractStatus.PAUSED:
                    valid = CurrentStatus == ContractStatus.RUNNING;
                    break;

                case ContractStatus.RUNNING:
                    valid = CurrentStatus == ContractStatus.INJECTED || CurrentStatus == ContractStatus.PAUSED || CurrentStatus == ContractStatus.WAITING;
                    break;

                case ContractStatus.FINALIZED:
                    valid = CurrentStatus == ContractStatus.RUNNING || CurrentStatus == ContractStatus.PAUSED;
                    break;
            }

            if (valid)
            {
                Status.OnNext(to);
            }
            else
            {
                throw new InternalException("Contract can't switch from status '{0}' to '{1}'", CurrentStatus, to);
            }
        }
    }
}
