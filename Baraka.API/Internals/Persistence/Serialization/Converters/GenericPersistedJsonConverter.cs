namespace Baraka.API.Internals.Persistence.Serialization.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Extensions;
    using Baraka.API.Internals.Persistence.Serialization.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Voir https://skrift.io/articles/archive/bulletproof-interface-deserialization-in-jsonnet
    ///     <see cref="JsonConverter{T}" />
    /// </summary>
    public class GenericPersistedJsonConverter : JsonConverter<IGenericPersistedDTO>
    {
        /// <summary>
        ///     Liste des convertisseurs internes.
        /// </summary>
        private static readonly JsonConverter[] CONVERTERS = new JsonConverter[]
        {
            new PersistedJsonReferencesConverter(),
            new PersistedJsonCollectionsConverter()
        };

        /// <summary>
        ///     <see cref="JsonConverter{T}.ReadJson(JsonReader, Type, T, bool, JsonSerializer)" />
        /// </summary>
        public override IGenericPersistedDTO ReadJson(JsonReader reader, Type objectType, IGenericPersistedDTO existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Récupération du type
            var obj = JObject.Load(reader);
            var val = obj[PersistedJsonContractResolver.TYPE_PROPERTY_NAME].Value<string>();

            // Récupération de la configuration
            var cfg = GenericJsonTypeIndex.GetConfigurationByType(objectType);
            var key = Enum.Parse(cfg.KeyType, val);
            var instance = cfg.UnsafeGetInstance(key);

            // Renvoi
            serializer.Populate(obj.CreateReader(), instance);
            return instance;
        }

        /// <summary>
        ///     <see cref="JsonConverter{T}.WriteJson(JsonWriter, object, JsonSerializer)" />
        /// </summary>
        public override void WriteJson(JsonWriter writer, IGenericPersistedDTO value, JsonSerializer serializer)
        {
            // Récupération de la configuration
            var cfg = GenericJsonTypeIndex.GetConfigurationByType(value.GetType());
            var kt = cfg.KeyType;
            var key = cfg.UnsafeGetNameByType(value.GetType());

            // Conversion
            var job = JObject.FromObject(value);
            job.Add(PersistedJsonContractResolver.TYPE_PROPERTY_NAME, key);

            // Ecriture
            job.WriteTo(writer, CONVERTERS);
        }
    }
}
