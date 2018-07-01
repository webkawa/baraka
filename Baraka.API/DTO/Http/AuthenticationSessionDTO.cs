namespace Baraka.API.DTO.Http
{
    using System;
    using Baraka.API.Entities;

    /// <summary>
    ///     DTO descriptif d'une session ouverte par un utilisateur dans
    ///     l'application.
    /// </summary>
    public class AuthenticationSessionDTO
    {
        /// <summary>
        ///     Statut de connexion.
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        ///     Jeton.
        /// </summary>
        public Guid Token { get; set; }

        /// <summary>
        ///     Utilisateur.
        /// </summary>
        public User User { get; set; }
    }
}