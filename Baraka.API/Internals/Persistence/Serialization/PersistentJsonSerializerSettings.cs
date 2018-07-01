namespace Baraka.API.Internals.Persistence.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Newtonsoft.Json;
    using NHibernate;

    /// <summary>
    ///     Paramètres de sérialisation des DTO mémorisés en JSON. 
    /// </summary>
    public class PersistentJsonSerializerSettings : JsonSerializerSettings
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PersistentJsonSerializerSettings()
        {
            ContractResolver = new PersistentJsonContractResolver();
            Converters = new List<JsonConverter>()
            {
                new PersistentJsonReferencesConverter(),
                new PersistentJsonCollectionsConverter()
            };
            Formatting = Formatting.None;
            ReferenceLoopHandling = ReferenceLoopHandling.Error;
        }
    }
}
