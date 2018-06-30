namespace Baraka.API.DTO.Persisted.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;

    /// <summary>
    ///     DTO descripive d'une vue localisée - à savoir, rattachée à une table.
    /// </summary>
    public abstract class LocalizedViewDTO : AbstractViewDTO
    {
        /// <summary>
        ///     Table de rattachement.
        /// </summary>
        public Table Table { get; set; }
    }
}
