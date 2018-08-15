namespace Baraka.API.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Exception du moteur.
    /// </summary>
    internal class EngineException : InternalException
    {
        /// <summary>
        ///     Constructeur simple.
        /// </summary>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formattage.</param>
        public EngineException(string message, params object[] format) : base(message, format)
        {
        }

        /// <summary>
        ///     Constructeur à charge.
        /// </summary>
        /// <param name="inner">Cause de l'erreur.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formattage.</param>
        public EngineException(Exception inner, string message, params object[] format) : base(inner, message, format)
        {
        }
    }
}
