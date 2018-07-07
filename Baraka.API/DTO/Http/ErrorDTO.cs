namespace Baraka.API.DTO.Http
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Baraka.API.DTO.Persisted.Shared;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    ///     DTO descriptif d'une erreur.
    /// </summary>
    public class ErrorDTO
    {
        /// <summary>
        ///     Code de l'erreur.
        /// </summary>
        public int Code { get; set; }
        
        /// <summary>
        ///     Message affiché.
        /// </summary>
        public BundleDTO Message { get; set; }
    }
}
