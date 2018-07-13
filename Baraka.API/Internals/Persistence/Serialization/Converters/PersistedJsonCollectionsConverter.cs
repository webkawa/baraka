namespace Baraka.API.Internals.Persistence.Serialization.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Convertisseur JSON adapté au stockage de références vers des collections d'entités 
    ///     persistentes stockées en base de données.
    /// </summary>
    public class PersistedJsonCollectionsConverter : JsonConverter<IPersistedCollectionDTO>
    {
        /// <summary>
        ///     <see cref="JsonConverter.ReadJson(JsonReader, Type, object, JsonSerializer)" />
        /// </summary>
        public override IPersistedCollectionDTO ReadJson(JsonReader reader, Type objectType, IPersistedCollectionDTO existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Création de l'instance
            IPersistedCollectionDTO instance = Activator.CreateInstance(objectType) as IPersistedCollectionDTO;

            // Lecture des valeurs
            JArray array = JArray.Load(reader);
            foreach (Guid id in array.Values<string>().Select(e => Guid.Parse(e)))
            {
                instance.Ids.Add(id);
            }

            // Renvoi
            return instance;
        }

        /// <summary>
        ///     <see cref="JsonConverter.WriteJson(JsonWriter, object, JsonSerializer)" />
        /// </summary>
        public override void WriteJson(JsonWriter writer, IPersistedCollectionDTO value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if (value == null)
            {
                foreach (Guid id in value.Ids)
                {
                    writer.WriteValue(id);
                }
            }

            writer.WriteEndArray();
        }
    }
}
