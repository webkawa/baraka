namespace Baraka.API.Internals.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;

    /// <summary>
    ///     Session authentifiée.
    /// </summary>
    internal class AuthenticationEntry
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="user">Utilisateur authentifié.</param>
        public AuthenticationEntry(User user)
        {
            Token = Guid.NewGuid();
            UID = user.Id;
            Timeout = user.Configuration.Timeout;
            Expiration = DateTime.Now.AddSeconds(user.Configuration.Timeout);
        }

        /// <summary>
        ///     Jeton d'authentification.
        /// </summary>
        internal Guid Token { get; private set; }

        /// <summary>
        ///     Identifiant de l'utilisateur.
        /// </summary>
        internal Guid UID { get; private set; }

        /// <summary>
        ///     Durée d'expiration fixée par l'utilisateur.
        /// </summary>
        internal long Timeout { get; set; }

        /// <summary>
        ///     Date d'expiration.
        /// </summary>
        internal DateTime Expiration { get; set; }
    }
}
