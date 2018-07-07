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
        ///     Liste des configurations.
        /// </summary>
        private static IDictionary<Type, IGenericJsonTypeConfiguration> Configurations { get; set; } = new Dictionary<Type, IGenericJsonTypeConfiguration>();

        /// <summary>
        ///     Retourne la configuration rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type de DTO recherché.</param>
        /// <returns>Configuration correspondante.</returns>
        public static IGenericJsonTypeConfiguration GetConfiguration(Type type)
        {
            Type buff = type;
            while (buff != null)
            {
                if (Configurations.ContainsKey(buff))
                {
                    return Configurations[buff];
                }

                buff = buff.BaseType;
            }

            throw new InternalException("Unable to found persistent DTO configuration for type '{0}'", type);
        }

        /// <summary>
        ///     Ajoute uen configuration dans l'index.
        /// </summary>
        /// <typeparam name="TBase">Type de base.</typeparam>
        /// <param name="configuration">Configuration ajoutée.</param>
        public static void AddConfiguration<TBase>(IGenericJsonTypeConfiguration configuration)
            where TBase : IGenericPersistedDTO
        {
            Configurations.Add(typeof(TBase), configuration);
        }
    }
}
