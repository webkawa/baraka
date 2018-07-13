namespace Baraka.API.Internals.Persistence.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Persistence.Serialization.Converters;
    using Newtonsoft.Json;
    using NHibernate;

    /// <summary>
    ///     Paramètres de sérialisation des DTO mémorisés en JSON. 
    /// </summary>
    public class PersistedJsonSerializerSettings : JsonSerializerSettings
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PersistedJsonSerializerSettings()
        {
            ContractResolver = new PersistedJsonContractResolver();
            Converters = new List<JsonConverter>()
            {
                new PersistedJsonReferencesConverter(),
                new PersistedJsonCollectionsConverter()
            };
            Formatting = Formatting.None;
            ReferenceLoopHandling = ReferenceLoopHandling.Error;
        }
    }
}
