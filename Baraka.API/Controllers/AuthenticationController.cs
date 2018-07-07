namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.DTO.Http;
    using Baraka.API.Entities;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Attributes;
    using Baraka.API.Internals.Authentication;
    using Baraka.API.Internals.Configuration;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Contrôleur de l'authentification.
    /// </summary>
    public class AuthenticationController
    {
        /// <summary>
        ///     Ouvre une connexion à l'application et retourne le jeton d'authentification.
        /// </summary>
        /// <param name="name">Login ou adresse e-mail.</param>
        /// <param name="password">Mot de passe.</param>
        /// <param name="manager">Gestionnaire d'authentification.</param>
        /// <param name="userDAO">DAO des utilisateurs.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/services/auth/connect")]
        public AuthenticationSessionDTO Connect(
            [FromQuery] string name,
            [FromQuery] string password,
            [FromServices] AuthenticationManager manager,
            [FromServices] UserDAO userDAO)
        {
            User user = userDAO.GetByCredentials(name, password);
            if (user == null)
            {
                throw new AuthenticationException("Invalid credentials")
                {
                    Display = BundleId.ERROR_INVALID_CREDENTIALS
                };
            }
            else
            {
                return new AuthenticationSessionDTO()
                {
                    Connected = true,
                    Token = manager.OpenEntry(user),
                    User = user
                };
            }
        }
    }
}