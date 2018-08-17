namespace Baraka.API.Internals.Engine.Contracts.Plans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Events;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Charge initiale d'un plan.
    ///     Classe représentative des évènements ou traitements initiaux 
    ///     constitutifs d'un plan d'exécution.
    /// </summary>
    internal interface IPlanStarter
    {
        /// <summary>
        ///     Liste des évènements à traiter.
        /// </summary>
        ISet<IEvent> Events { get; }

        /// <summary>
        ///     Liste des traitements exécutés.
        /// </summary>
        ISet<ITreatment> Treatments { get; }

        /// <summary>
        ///     Liste complète des contracts compris dans la charge 
        ///     initiale.
        /// </summary>
        IEnumerable<IContract> All { get; }
    }

    /// <summary>
    ///     Charge initiale d'un plan.
    /// </summary>
    internal class PlanStarter : IPlanStarter
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PlanStarter()
        {
            Events = new HashSet<IEvent>();
            Treatments = new HashSet<ITreatment>();
        }

        /// <summary>
        ///     Liste des évènements à traiter.
        /// </summary>
        public ISet<IEvent> Events { get; private set; }

        /// <summary>
        ///     Liste des traitements exécutés.
        /// </summary>
        public ISet<ITreatment> Treatments { get; private set; }

        /// <summary>
        ///     Liste complète des contracts compris dans la charge 
        ///     initiale.
        /// </summary>
        public IEnumerable<IContract> All => Enumerable.Union(
            Events.Cast<IContract>(),
            Treatments.Cast<IContract>());
    }
}
