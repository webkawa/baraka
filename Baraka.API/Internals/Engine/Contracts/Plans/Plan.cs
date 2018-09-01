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
        IPlanStarter Starter { get; }
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
        public Plan(IEngine engine, IPlanStarter starter) : base(engine)
        {
            Id = Guid.NewGuid();
            Starter = starter;
        }

        /// <summary>
        ///     Identifiant du plan.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        ///     Charge initiale.
        /// </summary>
        public IPlanStarter Starter { get; private set; }
    }
}
