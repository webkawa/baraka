namespace Baraka.API.Internals.Persistence.Serialization.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.Entities;
    using Baraka.API.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NHibernate;
    using NHibernate.Proxy;

    /// <summary>
    ///     Convertisseur JSON adapté aux proxys NHibernate.
    /// </summary>
    public class ProxyConverter : JsonConverter<INHibernateProxy>
    {
        /// <summary>
        ///     Nom de la propriété porteuse de l'identifiant.
        /// </summary>
        public readonly string ID_PROPERTY = LambdaExtensions.GetPropertyName<Entity, Guid>(e => e.Id).ToLower();

        /// <summary>
        ///     <see cref="JsonConverter.CanRead" />
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        ///     <see cref="JsonConverter{T}.ReadJson(JsonReader, Type, T, bool, JsonSerializer)" />
        /// </summary>
        public override INHibernateProxy ReadJson(JsonReader reader, Type objectType, INHibernateProxy existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Not implemented...");
        }

        /// <summary>
        ///     <see cref="JsonConverter{T}.WriteJson(JsonWriter, T, JsonSerializer)" />
        /// </summary>
        public override void WriteJson(JsonWriter writer, INHibernateProxy value, JsonSerializer serializer)
        {
            if (value.HibernateLazyInitializer.IsUninitialized)
            {
                writer.WriteStartObject();
                if (typeof(Entity).IsAssignableFrom(value.GetType()))
                {
                    writer.WritePropertyName(ID_PROPERTY);
                    writer.WriteValue((value as Entity).Id);
                }
                writer.WriteEndObject();
            }
            else
            {
                var job = JObject.FromObject(value);
                job.WriteTo(writer, serializer.Converters.ToArray());
            }
        }
    }
}
