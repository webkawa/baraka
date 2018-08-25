namespace Baraka.API.Internals.Engine.Contracts.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Text;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Processes.Implementations;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Processus.
    ///     Tâche unitaire mobilisant de manière intensive ou durable les
    ///     ressources propres de l'application (calculs, écritures de 
    ///     fichiers, etc.).
    /// </summary>
    internal interface IProcess : IContract
    {
        /// <summary>
        ///     Déclenchement du processus.
        /// </summary>
        void Launch();
    }

    /// <summary>
    ///     Processus.
    /// </summary>
    internal abstract class Process : Contract, IProcess
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public Process(IEngine engine) : base(engine)
        {
            SubProcesses = new HashSet<IContract>();
        }
        
        /// <summary>
        ///     Liste des sous-processus définis.
        /// </summary>
        private ISet<IContract> SubProcesses { get; set; }
        
        /// <summary>
        ///     Déclenchement du processus.
        /// </summary>
        public void Launch()
        {
            Execute();
            Wait(SubProcesses.ToArray()).Subscribe((results) =>
            {
                Finalize(ContractResult.SUCCESS);
            });
        }

        /// <summary>
        ///     Déclenche un traitement.
        /// </summary>
        /// <typeparam name="TTreatment">Type du traitement déclenché.</typeparam>
        /// <param name="treatment">Traitement.</param>
        /// <param name="postback">Actions consécutives aux traitement.</param>
        protected void RunTreatment<TTreatment>(TTreatment treatment, Action<QuickProcess> postback = null)
            where TTreatment : ITreatment
        {
            Run(treatment, Engine.TreatmentManager, postback, false);
        }

        /// <summary>
        ///     Déclenche un sous-processus.
        /// </summary>
        /// <typeparam name="TProcess">Type du traitement déclenché.</typeparam>
        /// <param name="process">Traitement.</param>
        /// <param name="postback">Actions consécutives aux traitement.</param>
        protected void RunProcess<TProcess>(TProcess process, Action<QuickProcess> postback = null)
            where TProcess : IProcess
        {
            Run(process, Engine.ProcessManager, postback, false);
        }

        /// <summary>
        ///     Déclenche un traitement détaché des plans d'exécution.
        /// </summary>
        /// <typeparam name="TTreatment">Type du traitement déclenché.</typeparam>
        /// <param name="treatment">Traitement.</param>
        /// <param name="postback">Actions consécutives aux traitement.</param>
        protected void RunTreatmentAsync<TTreatment>(TTreatment treatment, Action<QuickProcess> postback = null)
            where TTreatment : ITreatment
        {
            Run(treatment, Engine.TreatmentManager, postback, true);
        }

        /// <summary>
        ///     Déclenche un sous-processus détaché des plans d'exécution.
        /// </summary>
        /// <typeparam name="TProcess">Type du traitement déclenché.</typeparam>
        /// <param name="process">Traitement.</param>
        /// <param name="postback">Actions consécutives aux traitement.</param>
        protected void RunProcessAsync<TProcess>(TProcess process, Action<QuickProcess> postback = null)
            where TProcess : IProcess
        {
            Run(process, Engine.ProcessManager, postback, true);
        }

        /// <summary>
        ///     Exécution.
        /// </summary>
        protected abstract void Execute();

        /// <summary>
        ///     Injecte un contrat au sein d'un gestionnaire adapté et retourne l'observable
        ///     de finalisation.
        /// </summary>
        /// <typeparam name="TContract">Type de contrat injecté.</typeparam>
        /// <param name="contract">Contrat injecté.</param>
        /// <param name="manager">Gestionnaire utilisé.</param>
        /// <param name="postback">Actions complémentaires.</param>
        /// <param name="async">Mode asynchrone.</param>
        /// <returns>Observable correspondant.</returns>
        private IObservable<ContractResult> Run<TContract>(TContract contract, IContractManager<TContract> manager, Action<QuickProcess> postback, bool async)
            where TContract : IContract
        {
            // Gestion du statut
            if (CurrentStatus != ContractStatus.RUNNING)
            {
                throw new EngineException("Processes piling can only be done inside of an 'Execute()' treatment");
            }

            // Gestion de l'observable
            if (!async)
            {
                SubProcesses.Add(contract);
            }

            // Gestion du retour
            if (postback != null)
            {
                contract.OnFinalized.Subscribe((result) =>
                {
                    var sub = new QuickProcess(Engine, postback);
                    Engine.ProcessManager.Inject(sub);
                });
            }

            // Injection et renvoi
            manager.Inject(contract);
            return contract.OnFinalized;
        }
    }
}
