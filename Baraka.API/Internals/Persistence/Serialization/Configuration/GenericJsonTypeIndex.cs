namespace Baraka.API.Internals.Persistence.Serialization.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Exceptions;

    /// <summary>
    ///     Index des configurations de DTO génériques.
    /// </summary>
    public static class GenericJsonTypeIndex
    {
        /// <summary>
        ///     Liste des configurations par type.
        /// </summary>
        private static IDictionary<Type, IGenericJsonTypeConfiguration> TypeToConfigurations { get; set; } = new Dictionary<Type, IGenericJsonTypeConfiguration>();

        /// <summary>
        ///     Liste des configurations par clef.
        /// </summary>
        private static IDictionary<Type, IGenericJsonTypeConfiguration> KeyToConfiguration { get; set; } = new Dictionary<Type, IGenericJsonTypeConfiguration>();

        /// <summary>
        ///     Retourne la configuration rattachée à un type de clef.
        /// </summary>
        /// <param name="type">Type de clef recherché.</param>
        /// <returns>Configuration correspondante.</returns>
        public static IGenericJsonTypeConfiguration GetConfigurationByKey(Type type)
        {
            return FindForType(type, KeyToConfiguration);
        }

        /// <summary>
        ///     Retourne la configuration rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type de DTO recherché.</param>
        /// <returns>Configuration correspondante.</returns>
        public static IGenericJsonTypeConfiguration GetConfigurationByType(Type type)
        {
            return FindForType(type, TypeToConfigurations);
        }

        /// <summary>
        ///     Ajoute uen configuration dans l'index.
        /// </summary>
        /// <typeparam name="TKey">Type de clef.</typeparam>
        /// <typeparam name="TBase">Type de base.</typeparam>
        /// <param name="configuration">Configuration ajoutée.</param>
        public static void AddConfiguration<TKey, TBase>(IGenericJsonTypeConfiguration configuration)
            where TBase : IGenericPersistedDTO
        {
            KeyToConfiguration.Add(typeof(TKey), configuration);
            TypeToConfigurations.Add(typeof(TBase), configuration);
        }

        /// <summary>
        ///     Explore un dictionnaire à la recherche d'un type passé en paramètre ou de 
        ///     ses types de base.
        /// </summary>
        /// <param name="type">Type exploré.</param>
        /// <param name="source">Dictionnaire source.</param>
        /// <returns>Configuration.</returns>
        private static IGenericJsonTypeConfiguration FindForType(Type type, IDictionary<Type, IGenericJsonTypeConfiguration> source)
        {
            Type buff = type;
            while (buff != null)
            {
                if (source.ContainsKey(buff))
                {
                    return source[buff];
                }

                buff = buff.BaseType;
            }

            throw new InternalException("Unable to found persistent DTO configuration for type '{0}'", type);
        }
    }
}
