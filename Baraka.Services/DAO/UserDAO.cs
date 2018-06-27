namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;
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
        /// <param name="password">Mot de passe.</param>
        /// <returns>Utilisateur créé.</returns>
        public User Insert(string login, string password)
        {
            User user = new User()
            {
                Login = login,
                Password = password
            };
            Session.Persist(user);
            return user;
        }
    }
}
