namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Configurations;
    using Baraka.API.Entities;
    using Baraka.API.Extensions;
    using NHibernate;

    /// <summary>
    ///     DAO des utilisateurs.
    /// </summary>
    public class UserDAO : AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session.</param>
        public UserDAO(ISession session) : base(session)
        {
        }
        
        /// <summary>
        ///     Génère et retourne un utilisateur.
        /// </summary>
        /// <param name="login">Login.</param>
        /// <param name="password">Mot de passe non-encrypté.</param>
        /// <param name="email">Adresse e-mail.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Utilisateur créé.</returns>
        public User Insert(string login, string password, string email, UserConfigurationDTO configuration)
        {
            User user = new User()
            {
                Login = login,
                Password = password.ToSHA256(),
                Email = email,
                Configuration = configuration
            };
            Session.Persist(user);
            return user;
        }
    }
}
