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

    /// <summary>
    ///     Statut d'un contrat.
    /// </summary>
    internal enum ContractStatus
    {
        /// <summary>
        ///     Statut initial.
        /// </summary>
        INITIAL,

        /// <summary>
        ///     En attente.
        /// </summary>
        INJECTED,

        /// <summary>
        ///     En cours d'exécution.
        /// </summary>
        RUNNING,

        /// <summary>
        ///     En pause.
        /// </summary>
        PAUSED,

        /// <summary>
        ///     Finalisé.
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
        ///     Annulée.
        /// </summary>
        CANCELED,

        /// <summary>
        ///     Erreur.
        /// </summary>
        ERROR
    }

    /// <summary>
    ///     Interface des contrats.
    /// </summary>
    internal interface IContract
    {
        /// <summary>
        ///     Moteur.
        /// </summary>
        Engine Engine { get; }

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
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public Contract(Engine engine)
        {
            Engine = engine;
            Status = new BehaviorSubject<ContractStatus>(ContractStatus.INITIAL);
            Result = new AsyncSubject<ContractResult>();
        }
        
        /// <summary>
        ///     Moteur applicatif.
        /// </summary>
        public Engine Engine { get; private set; }

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
                    valid = CurrentStatus == ContractStatus.INJECTED || CurrentStatus == ContractStatus.PAUSED;
                    break;

                case ContractStatus.FINALIZED:
                    valid = CurrentStatus == ContractStatus.RUNNING;
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
