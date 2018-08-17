namespace Baraka.API.Internals.Engine.Managers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Events;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Gestionnaire des plans.
    ///     Classe dédiée à l'ordonnancement des plans gérés par le moteur.
    ///     Fait office de point d'entrée et de sortie principal pour toutes
    ///     les classes externes.
    /// </summary>
    internal interface IPlanManager : IContractManager<IPlan>
    {
    }

    /// <summary>
    ///     Gestionnaire des plans.
    /// </summary>
    internal class PlanManager : ContractManager<IPlan>, IPlanManager
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur d'appartenance.</param>
        public PlanManager(IEngine engine) : base(engine)
        {
            OnContractInjected.Subscribe((contract) =>
            {
                // Mise en attente
                contract.Wait(contract.Starter.All.ToArray()).Subscribe((results) =>
                {
                    contract.Finalize(ContractResult.SUCCESS);
                });

                // Injection
                foreach (ITreatment treatment in contract.Starter.Treatments)
                {
                    Engine.TreatmentManager.Inject(treatment);
                }
                foreach (IEvent evt in contract.Starter.Events)
                {
                    Engine.EventManager.Inject(evt);
                }
            });
        }
    }
}
