namespace Baraka.API.Internals.Persistence.Serialization.Converters
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
    public class PersistedJsonReferencesConverter : JsonConverter<IPersistedReferenceDTO>
    {
        /// <summary>
        ///     <see cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)" />
        /// </summary>
        public override IPersistedReferenceDTO ReadJson(JsonReader reader, Type objectType, IPersistedReferenceDTO existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            IPersistedReferenceDTO instance = Activator.CreateInstance(objectType) as IPersistedReferenceDTO;
            instance.Id = Guid.Parse(reader.Value?.ToString() ?? Guid.Empty.ToString());
            return instance;
        }

        /// <summary>
        ///     <see cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)" />
        /// </summary>
        public override void WriteJson(JsonWriter writer, IPersistedReferenceDTO value, JsonSerializer serializer)
        {
            writer.WriteValue((value as IPersistedReferenceDTO).Id);
        }
    }
}
