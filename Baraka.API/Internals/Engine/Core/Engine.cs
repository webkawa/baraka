namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Text;

    using Baraka.API.Internals.Configuration;
    using Baraka.API.Internals.Engine.Managers;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Interface du moteur de l'application.
    /// </summary>
    internal interface IEngine
    {
        /// <summary>
        ///     Gestionnaire des plans.
        /// </summary>
        IPlanManager PlanManager { get; }

        /// <summary>
        ///     Gestionnaire des traitements.
        /// </summary>
        ITreatmentManager TreatmentManager { get; }

        /// <summary>
        ///     Gestionnaire évènementiel.
        /// </summary>
        EventManager EventManager { get; }

        /// <summary>
        ///     Gestionnaire d'instructions.
        /// </summary>
        InstructionManager InstructionManager { get; }

        /// <summary>
        ///     Gestionnaire de processus.
        /// </summary>
        ProcessManager ProcessManager { get; }

        /// <summary>
        ///     Gestionnaire de tâches.
        /// </summary>
        JobManager JobManager { get; }

        /// <summary>
        ///     Configuration du moteur.
        /// </summary>
        EngineConfiguration Configuration { get; }

        /// <summary>
        ///     A l'activité d'un contrat dans le moteur.
        /// </summary>
        IObservable<IContract> OnEngineActivity { get; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        ILogger Logger { get; }
    }

    /// <summary>
    ///     Interface des composants rattachés au moteur de 
    ///     l'application.
    /// </summary>
    internal interface IEngineAttached
    {
        IEngine Engine { get; }
    }

    /// <summary>
    ///     Moteur.
    ///     Moteur de l'application.
    /// </summary>
    internal class Engine : IEngine
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="configuration">Configuration du moteur.</param>
        /// <param name="logger">Gestionnaire de logs.</param>
        public Engine(EngineConfiguration configuration, ILogger logger)
        {
            Logger = logger;
            PlanManager = new PlanManager(this);
        }

        /// <summary>
        ///     Gestionnaire des plans.
        /// </summary>
        public IPlanManager PlanManager { get; private set; }

        /// <summary>
        ///     Gestionnaire des traitements.
        /// </summary>
        public ITreatmentManager TreatmentManager { get; private set; }

        /// <summary>
        ///     Gestionnaire évènementiel.
        /// </summary>
        public EventManager EventManager { get; private set; }

        /// <summary>
        ///     Gestionnaire d'instructions.
        /// </summary>
        public InstructionManager InstructionManager { get; private set; }

        /// <summary>
        ///     Gestionnaire de processus.
        /// </summary>
        public ProcessManager ProcessManager { get; private set; }

        /// <summary>
        ///     Gestionnaire de tâches.
        /// </summary>
        public JobManager JobManager { get; private set; }

        /// <summary>
        ///     Configuration du moteur.
        /// </summary>
        public EngineConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        public ILogger Logger { get; private set; }

        /// <summary>
        ///     A l'activité d'un contrat dans le moteur.
        /// </summary>
        public IObservable<IContract> OnEngineActivity => Observable
            .Merge(
                PlanManager.OnContractActivity.Cast<IContract>(),
                TreatmentManager.OnContractActivity,
                EventManager.OnContractActivity,
                InstructionManager.OnContractActivity,
                ProcessManager.OnContractActivity,
                JobManager.OnContractActivity);
    }
}
