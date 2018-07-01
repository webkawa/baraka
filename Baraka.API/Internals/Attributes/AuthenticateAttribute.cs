namespace Baraka.API.Internals.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;
    using Baraka.API.Internals.Authentication;
    using Microsoft.AspNetCore.Mvc.Filters;
    using NHibernate;

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
        ///     Méthode d'ouverture de la transaction.
        /// </summary>
        /// <param name="context">Contexte d'exécution.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Récupération de la session
            var session = context
                .HttpContext
                .RequestServices
                .GetService(typeof(ISession)) as ISession;

            // Récupération du gestionnaire
            var manager = context
                .HttpContext
                .RequestServices
                .GetService(typeof(AuthenticationManager)) as AuthenticationManager;

            // Récupération du porte-autorisations
            var holder = context
                .HttpContext
                .RequestServices
                .GetService(typeof(AuthenticationHolder)) as AuthenticationHolder;

            // Récupération du jeton
            string token = context
                .HttpContext
                .Request
                .Headers[HEADER]
                .ToString();

            try
            {
                // Gestion du type
                Guid guid;
                if (string.IsNullOrEmpty(token))
                {
                    throw new Error("No token found in request...");
                }
                if (!Guid.TryParse(token, out guid))
                {
                    throw new Error("Token parsing failed...");
                }

                // Vérification du jeton
                Guid user = manager.CheckEntry(guid);

                // Mise à jour du porte-autorisation
                holder.Fill(session.Get<User>(user));
            }
            catch (Exception ex)
            {
                throw new Error(ex, "Token-based authentication failed...");
            }
        }
    }
}
