namespace Baraka.API.Internals.Persistence.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using NHibernate;
    using Baraka.API.DTO.Persisted.Abstract;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Convertisseur JSON adapté au stockage de références vers des entités persistentes
    ///     stockées en base de données.
    /// </summary>
    public class PersistentJsonReferencesConverter : JsonConverter
    {
        /// <summary>
        ///     <see cref="JsonConverter.CanConvert(Type)" />
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return typeof(IPersistedReferenceDTO).IsAssignableFrom(objectType);
        }

        /// <summary>
        ///     <see cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)" />
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IPersistedReferenceDTO instance = Activator.CreateInstance(objectType) as IPersistedReferenceDTO;
            instance.Id = Guid.Parse(reader.Value?.ToString() ?? Guid.Empty.ToString());
            return instance;
        }

        /// <summary>
        ///     <see cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)" />
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((value as IPersistedReferenceDTO).Id);
        }
    }
}
