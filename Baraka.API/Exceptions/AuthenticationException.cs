namespace Baraka.API.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Configuration;

    /// <summary>
    ///     Erreur liée à l'authentification.
    /// </summary>
    internal class AuthenticationException : ApiException
    {
        /// <summary>
        ///     Constructeur simple.
        /// </summary>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public AuthenticationException(string message, params object[] format) : base(message, format)
        {
            Display = BundleId.ERROR_UNKNOW_AUTHENTICATION;
        }

        /// <summary>
        ///     Constructeur à charge.
        /// </summary>
        /// <param name="inner">Cause de l'erreur.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public AuthenticationException(Exception inner, string message, params object[] format) : base(inner, message, format)
        {
            Display = (inner as AuthenticationException)?.Display ?? BundleId.ERROR_UNKNOW_AUTHENTICATION;
        }
    }
}
