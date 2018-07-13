namespace Baraka.API.DTO.Persisted.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Entities;

    /// <summary>
    ///     Configuration d'une référence.
    /// </summary>
    public class ReferenceFieldConfigurationDTO : AbstractFieldConfigurationDTO
    {
        /// <summary>
        ///     Table de destination.
        /// </summary>
        public PersistedReferenceDTO<Table> Destination { get; set; }
    }
}
