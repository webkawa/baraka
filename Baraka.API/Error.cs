namespace Baraka.API
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Erreur.
    /// </summary>
    public class Error : Exception
    {
        /// <summary>
        ///     Constructeur simple.
        /// </summary>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formattage.</param>
        public Error(string message, params string[] format) : base(string.Format(message, format))
        {
        }

        /// <summary>
        ///     Constructeur à charge.
        /// </summary>
        /// <param name="inner">Cause de l'erreur.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formattage.</param>
        public Error(Exception inner, string message, params string[] format) : base(string.Format(message, format), inner)
        {
        }
    }
}
