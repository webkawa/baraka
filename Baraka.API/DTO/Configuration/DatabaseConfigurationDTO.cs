namespace Baraka.API.DTO.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Configuration de la connexion à la base de données.
    /// </summary>
    public class DatabaseConfigurationDTO
    {
        /// <summary>
        ///     Chaîne de connexion.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        ///     Taille des lots.
        /// </summary>
        public short BatchSize { get; set; }

        /// <summary>
        ///     Action.
        /// </summary>
        public string Action { get; set; }
    }
}
