namespace Baraka.API.Internals.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;
    using Baraka.API.Exceptions;

    /// <summary>
    ///     Service permettant le stockage du statut d'autentification rattaché à la requête
    ///     courante.
    /// </summary>
    public class AuthenticationHolder
    {
        /// <summary>
        ///     Identifiant courant (attribut).
        /// </summary>
        private User _currentAttribute;

        /// <summary>
        ///     Constructeur.
        /// </summary>
        public AuthenticationHolder()
        {
            Connected = false;
            Current = null;
        }

        /// <summary>
        ///     Statut de connexion.
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        ///     Identifiant courant.
        /// </summary>
        public User Current
        {
            get
            {
                if (_currentAttribute == null)
                {
                    throw new AuthenticationException("Access to authentication holder failed...");
                }

                return _currentAttribute;
            }
            private set
            {
                _currentAttribute = value;
            }
        }

        /// <summary>
        ///     Affecte un jeton à la requête courante.
        /// </summary>
        /// <param name="current">Requête courante.</param>
        public void Fill(User current)
        {
            if (Connected)
            {
                throw new AuthenticationException("Application tried to rewrite autorisations from user...");
            }
            else
            {
                Connected = true;
                Current = current;
            }
        }
    }
}
