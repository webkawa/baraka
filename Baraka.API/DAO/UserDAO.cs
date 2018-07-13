namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Users;
    using Baraka.API.Entities;
    using Baraka.API.Extensions;
    using Baraka.API.Internals.Model;
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
        /// <param name="user">Utilisateur inséré avec mot de passe en clair.</param>
        /// <returns>Utilisateur créé.</returns>
        public User Insert(User user)
        {
            // Encryptage du mot de passe
            user.Password = user.Password.ToSHA256();

            // Insertion
            GetValidator().Check(user);
            Session.Persist(user);
            return user;
        }

        /// <summary>
        ///     Retourne un utilisateur par le biais de ses identifiants.
        /// </summary>
        /// <param name="name">Login ou adresse e-mail.</param>
        /// <param name="password">Mot de passe non-encrypté.</param>
        /// <returns>Utilisateur existant ou null.</returns>
        public User GetByCredentials(string name, string password)
        {
            return Session
                .QueryOver<User>()
                .Where(e => e.Login == name || e.Email == name)
                .And(e => e.Password == password.ToSHA256())
                .SingleOrDefault();
        }
    }
}
