namespace Baraka.API.Internals.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Authentication;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    ///     Attribut vérifiant les droits d'un utilisateur avant accès à un contrôleur
    ///     ou une méthode.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Authenticate : ActionFilterAttribute
    {
        /// <summary>
        ///     Paramètre d'en-tête porteur du jeton.
        /// </summary>
        public const string HEADER = "token";

        /// <summary>
        ///     Gestionnaire d'authentification.
        /// </summary>
        private AuthenticationManager Manager { get; set; }

        /// <summary>
        ///     Méthode d'ouverture de la transaction.
        /// </summary>
        /// <param name="context">Contexte d'exécution.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Récupération de la session
            Manager = context
                .HttpContext
                .RequestServices
                .GetService(typeof(AuthenticationManager)) as AuthenticationManager;

            // Récupération du jeton
            string token = context
                .HttpContext
                .Request
                .Headers[HEADER]
                .ToString();

            try
            {
                Guid guid = Guid.Parse(token);
                Manager.CheckEntry(guid);
            }
            catch (Exception ex)
            {
                throw new Error(ex, "Token-based authentication failed...");
            }
        }
    }
}
