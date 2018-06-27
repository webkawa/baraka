namespace Baraka.API.Entities
{
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
        }
    }
}
