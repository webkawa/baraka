namespace Baraka.API.Internals.Engine.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Events;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Gestionnaire évènementiel.
    ///     Classe dédiée à l'analyse des évènements d'écriture survenus en 
    ///     base de données.
    /// </summary>
    internal interface IEventManager : IContractManager<IEvent>
    {
    }

    /// <summary>
    ///     Gestionnaire évènementiel.
    /// </summary>
    internal class EventManager : ContractManager<IEvent>, IEventManager
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public EventManager(IEngine engine) : base(engine)
        {
        }
    }
}
