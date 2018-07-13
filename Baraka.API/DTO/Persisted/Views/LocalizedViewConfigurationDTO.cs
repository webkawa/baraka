namespace Baraka.API.DTO.Persisted.Views
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Entities;

    /// <summary>
    ///     DTO descripive d'une vue localisée - à savoir, rattachée à une table.
    /// </summary>
    public abstract class LocalizedViewConfigurationDTO : AbstractViewConfigurationDTO
    {
        /// <summary>
        ///     Table de rattachement.
        /// </summary>
        public PersistedReferenceDTO<Table> Table { get; set; }
    }
}
