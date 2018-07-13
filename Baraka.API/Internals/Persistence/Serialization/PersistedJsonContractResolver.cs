namespace Baraka.API.Internals.Persistence.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     Gestionnaire de contrats applicables aux DTO stockés en JSON.
    /// </summary>
    public class PersistedJsonContractResolver : DefaultContractResolver
    {
        /// <summary>
        ///     Nom de la propriété "Type".
        /// </summary>
        internal const string TYPE_PROPERTY_NAME = "type";

        /// <summary>
        ///     <see cref="DefaultContractResolver.CreateProperty(MemberInfo, MemberSerialization)" />
        /// </summary>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType.Equals(typeof(IGenericPersistedDTO)) && member.Name.Equals(TYPE_PROPERTY_NAME))
            {
                property.Ignored = true;
            }

            return property;
        }
    }
}
