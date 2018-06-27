namespace Baraka.API.Entities
{
    using Baraka.API.Internals.Persistence;
    using NHibernate.Mapping.ByCode.Conformist;
    using System;
    using System.Collections.Generic;
    using System.Text;

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
        public virtual string Password { get; set; }

        /// <summary>
        ///     Adresse e-mail.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///     Configuration.
        /// </summary>
        public virtual UserConfiguration Configuration { get; set; }
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
            Property(
                e => e.Configuration, 
                m => m.Type<JsonType<UserConfiguration>>());
        }
    }
    
    /// <summary>
    ///     Configuration utilisateur.
    /// </summary>
    [Serializable]
    public class UserConfiguration
    {
        public string Test { get; set; }
        public string Test2 { get; set; }
    }
}
