namespace Baraka.API.Internals.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     DTO descriptif de la configuration des logs.
    /// </summary>
    public class LoggerConfiguration
    {
        /// <summary>
        ///     Dossier des logs.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        ///     Niveau minimal.
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        ///     Nombre maximum de fichiers conservés.
        /// </summary>
        public int Until { get; set; }
    }
}
