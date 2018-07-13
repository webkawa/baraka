namespace Baraka.API.DTO.Persisted.Users
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
    public class UserConfigurationDTO : FixedPersistedDTO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public UserConfigurationDTO()
        {
            Culture = Langage.FRA;
            Timeout = 60 * 20;
        }

        /// <summary>
        ///     Langue de l'utilisateur.
        /// </summary>
        public virtual Langage Culture { get; set; }

        /// <summary>
        ///     Durée d'expiration des sessions en secondes.
        /// </summary>
        public virtual long Timeout { get; set; }
    }
}
