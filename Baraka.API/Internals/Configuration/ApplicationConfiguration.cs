namespace Baraka.API.Internals.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     DTO descriptif de la configuration de l'application.
    /// </summary>
    public class ApplicationConfiguration
    {
        /// <summary>
        ///     Base de données.
        /// </summary>
        public DatabaseConfiguration Database { get; set; }

        /// <summary>
        ///     Gestions des logs.
        /// </summary>
        public LoggerConfiguration Logging { get; set; }
    }
}
