namespace Baraka.API.Internals.Engine.Contracts.Plans
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Interface des plans.
    /// </summary>
    internal interface IPlan : IContract
    {
        /// <summary>
        ///     Identifiant du plan.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Charge initiale.
        /// </summary>
        PlanStarter Starter { get; }

        /// <summary>
        ///     Options.
        /// </summary>
        PlanOptions Options { get; }

        /// <summary>
        ///     Cartographie du plan.
        /// </summary>
        PlanMap Map { get; }

        /// <summary>
        ///     A la finalisation de tous les éléments contenus dans la
        ///     charge initiale.
        /// </summary>
        IObservable<IEnumerable<ContractResult>> OnStarterFinalized { get; }
    }

    /// <summary>
    ///     Interface des éléments rattachés à un plan.
    /// </summary>
    internal interface IPlanAttached
    {
        /// <summary>
        ///     Plan rattaché.
        /// </summary>
        IPlan Plan { get; }
    }

    /// <summary>
    ///     Plan.
    ///     Objet représentatif d'un ensemble d'actions exécutées au niveau du moteur
    ///     et présentant des liens de causalités directs (propagation). Les actions
    ///     regroupées derrière un même plan peuvent être priorisées différemment
    ///     selon les caractéristiques de ce dernier (transaction SQL unique, présence 
    ///     et nature des souscripteurs, etc.).
    /// </summary>
    internal class Plan : Contract, IPlan
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        /// <param name="starter">Charge initiale.</param>
        /// <param name="options">Options.</param>
        public Plan(Engine engine, PlanStarter starter, PlanOptions options) : base(engine)
        {
            Id = Guid.NewGuid();
            Starter = starter;
            Options = options;
            Map = new PlanMap(this);
        }

        /// <summary>
        ///     Identifiant du plan.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        ///     Charge initiale.
        /// </summary>
        public PlanStarter Starter { get; private set; }

        /// <summary>
        ///     Options.
        /// </summary>
        public PlanOptions Options { get; private set; }

        /// <summary>
        ///     Cartographie du plan.
        /// </summary>
        public PlanMap Map { get; private set; }

        /// <summary>
        ///     A la finalisation de tous les éléments contenus dans la
        ///     charge initiale.
        /// </summary>
        public IObservable<IEnumerable<ContractResult>> OnStarterFinalized => Starter.OnAllFinalized;
    }
}
