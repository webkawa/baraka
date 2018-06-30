namespace Baraka.API.DTO.Persisted.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.DTO.Persisted.Shared;

    /// <summary>
    ///     Configuration utilisateur.
    /// </summary>
    [Serializable]
    public class UserConfigurationDTO : FixedPersistedDTO
    {
        /// <summary>
        ///     Langue de l'utilisateur.
        /// </summary>
        public virtual Langage Culture { get; set; }
    }
}
