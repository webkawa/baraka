namespace Baraka.API.DTO.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     DTO descriptif de la configuration de l'application.
    /// </summary>
    public class ApplicationConfigurationDTO
    {
        /// <summary>
        ///     Base de données.
        /// </summary>
        public DatabaseConfigurationDTO Database { get; set; }

        /// <summary>
        ///     Gestions des logs.
        /// </summary>
        public LoggingConfigurationDTO Logging { get; set; }
    }
}
