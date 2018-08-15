namespace Baraka.API.Internals.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;

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

        /// <summary>
        ///     Moteur.
        /// </summary>
        public EngineConfiguration Engine { get; set; }

        /// <summary>
        ///     Liste des lots.
        /// </summary>
        public IDictionary<BundleId, BundleDTO> Bundles { get; set; }
    }
}
