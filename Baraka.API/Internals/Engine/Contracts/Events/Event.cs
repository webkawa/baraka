namespace Baraka.API.Internals.Engine.Contracts.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Evènement.
    ///     Classe descriptive d'une opération d'écriture (C.UD) planifiée ou exécutée au
    ///     niveau de la base de données et susceptible de déclencher des traitements 
    ///     complémentaires.
    /// </summary>
    internal interface IEvent : IContract
    {
    }

    /// <summary>
    ///     Evènement.
    /// </summary>
    internal class Event : Contract, IEvent
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur d'origine.</param>
        public Event(IEngine engine) : base(engine)
        {
        }
    }
}
