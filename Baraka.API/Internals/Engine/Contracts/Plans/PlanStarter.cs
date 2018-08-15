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
    internal class PlanStarter
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PlanStarter()
        {
            Events = new HashSet<Event>();
            Treatments = new HashSet<Treatment>();
        }

        /// <summary>
        ///     Liste des évènements à traiter.
        /// </summary>
        internal ISet<Event> Events { get; private set; }

        /// <summary>
        ///     Liste des traitements exécutés.
        /// </summary>
        internal ISet<Treatment> Treatments { get; private set; }

        /// <summary>
        ///     Liste complète des contracts compris dans la charge 
        ///     initiale.
        /// </summary>
        internal IEnumerable<Contract> All => Enumerable.Union(
            Events.Cast<Contract>(),
            Treatments.Cast<Contract>());
        
        /// <summary>
        ///     A la finalisation de tous les contrats prévus dans 
        ///     la charge initiale.
        /// </summary>
        internal IObservable<IEnumerable<ContractResult>> OnAllFinalized => All
            .Select(e => e.OnFinalized)
            .Zip();
    }
}
