namespace Baraka.API.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Http;
    using Baraka.API.Internals.Configuration;

    /// <summary>
    ///     Erreur interne de l'API.
    ///     Classe parente des exceptions levées par l'API.
    /// </summary>
    internal abstract class ApiException : Exception
    {
        /// <summary>
        ///     Constructeur simple.
        /// </summary>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public ApiException(string message, params object[] format) : base(string.Format(message, format))
        {
            Display = BundleId.ERROR_UNKNOW;
        }

        /// <summary>
        ///     Constructeur à charge.
        /// </summary>
        /// <param name="inner">Cause de l'erreur.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public ApiException(Exception inner, string message, params object[] format) : base(string.Format(message, format), inner)
        {
            Display = (inner as ApiException)?.Display ?? BundleId.ERROR_UNKNOW;
        }

        /// <summary>
        ///     Message d'erreur affiché.
        /// </summary>
        internal BundleId Display { get; set; }
    }
}
