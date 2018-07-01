namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Configurations;
    using Baraka.API.Internals.Persistence;
    using Baraka.API.Internals.Persistence.Types;
    using Newtonsoft.Json;
    using NHibernate.Mapping.ByCode.Conformist;

    /// <summary>
    ///     Utilisateur.
    /// </summary>
    public class User : Entity
    {
        /// <summary>
        ///     Mot de passe.
        /// </summary>
        public virtual string Login { get; set; }

        /// <summary>
        ///     Mot de passe.
        /// </summary>
        [JsonIgnore]
        public virtual string Password { get; set; }

        /// <summary>
        ///     Adresse e-mail.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///     Configuration.
        /// </summary>
        public virtual UserConfigurationDTO Configuration { get; set; }
    }

    /// <summary>
    ///     Classe de mappage des utilisateurs.
    /// </summary>
    public class UserMapping : EntityMapping<User>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public UserMapping()
        {
            Property(e => e.Login);
            Property(e => e.Password);
            Property(e => e.Email);
            PropertyJsonFixed(e => e.Configuration);
        }
    }
}
