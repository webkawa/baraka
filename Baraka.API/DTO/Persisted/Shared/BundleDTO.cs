namespace Baraka.API.DTO.Persisted.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Liste des langages supportés.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Langage
    {
        /// <summary>
        ///     Français.
        /// </summary>
        FRA,

        /// <summary>
        ///     Anglais.
        /// </summary>
        ENG
    }

    /// <summary>
    ///     Lot de traductions.
    /// </summary>
    public class BundleDTO : FixedPersistedDTO
    {
        public BundleDTO()
        {
            Data = new Dictionary<Langage, string>();
        }

        /// <summary>
        ///     Liste des traductions.
        ///     Les éléments sont classés par code ISO-639-2.
        /// </summary>
        public virtual IDictionary<Langage, string> Data { get; set; }
    }
}
