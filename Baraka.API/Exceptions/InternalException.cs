namespace Baraka.API.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Configuration;

    /// <summary>
    ///     Erreur interne.
    /// </summary>
    internal class InternalException : ApiException
    {
        /// <summary>
        ///     Constructeur simple.
        /// </summary>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public InternalException(string message, params object[] format) : base(message, format)
        {
            Display = BundleId.ERROR_UNKNOW_INTERNAL;
        }

        /// <summary>
        ///     Constructeur à charge.
        /// </summary>
        /// <param name="inner">Cause de l'erreur.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public InternalException(Exception inner, string message, params object[] format) : base(inner, message, format)
        {
            Display = (inner as InternalException)?.Display ?? BundleId.ERROR_UNKNOW_INTERNAL;
        }
    }
}
