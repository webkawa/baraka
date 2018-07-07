namespace Baraka.API.Internals.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.Entities;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Configuration;

    /// <summary>
    ///     Gestionnaire d'authenfication.
    ///     Répertoire référençant les sessions ouvertes dans l'application.
    /// </summary>
    public class AuthenticationManager
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public AuthenticationManager()
        {
            Entries = new HashSet<AuthenticationEntry>();
        }

        /// <summary>
        ///     Liste des entrées.
        /// </summary>
        internal ISet<AuthenticationEntry> Entries { get; set; }

        /// <summary>
        ///     Ouvre une entrée dans le registre et retourne le jeton.
        /// </summary>
        /// <param name="user">Utilisateur authentifié.</param>
        /// <returns>Jeton de la session.</returns>
        public Guid OpenEntry(User user)
        {
            var add = new AuthenticationEntry(user);
            Entries.Add(add);
            return add.Token;
        }

        /// <summary>
        ///     Clôture une entrée du registre.
        /// </summary>
        /// <param name="token">Jeton de la session.</param>
        /// <returns>true en cas d'entrée trouvée, false sinon.</returns>
        public bool CloseEntry(Guid token)
        {
            AuthenticationEntry entry = Entries.SingleOrDefault(e => e.Token == token);
            return Entries.Remove(entry);
        }

        /// <summary>
        ///     Vérfication d'un jeton.
        /// </summary>
        /// <param name="token">Jeton vérifié.</param>
        /// <returns>ID de l'utilisateur.</returns>
        internal Guid CheckEntry(Guid token)
        {
            try
            {
                // Recherche de l'entrée.
                AuthenticationEntry entry = Entries.Single(e => e.Token == token);

                // Vérification de l'entrée
                if (entry == null)
                {
                    throw new AuthenticationException("Invalid token '{0}'...", token)
                    {
                        Display = BundleId.ERROR_INVALID_TOKEN
                    };
                }

                // Vérification de l'expiration
                if (DateTime.Now > entry.Expiration)
                {
                    Entries.Remove(entry);
                    throw new AuthenticationException("Session has expired...")
                    {
                        Display = BundleId.ERROR_EXPIRED_SESSION
                    };
                }

                // Mise à niveau de l'expiration et renvoi
                entry.Expiration = DateTime.Now.AddSeconds(entry.Timeout);
                return entry.UID;
            }
            catch (Exception ex)
            {
                throw new AuthenticationException(ex, "Authentication failed !");
            }
        }
    }
}
