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
    public class PersistentJsonSerializerSettings : JsonSerializerSettings
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="excPerGenTypes">Indique si le type des types persistents génériques doit être inclu dans la sérialisation.</param>
        public PersistentJsonSerializerSettings(bool excPerGenTypes)
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
