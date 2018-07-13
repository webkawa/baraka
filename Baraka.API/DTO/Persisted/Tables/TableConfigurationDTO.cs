namespace Baraka.API.DTO.Persisted.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;

    /// <summary>
    ///     DTO représentative de la configuration d'une table.
    /// </summary>
    public class TableConfigurationDTO : FixedPersistedDTO
    {
        /// <summary>
        ///     Table archivée.
        /// </summary>
        public bool Archived { get; set; }
    }
}
