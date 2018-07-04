namespace Baraka.API.Internals.Persistence.Serialization.Configuration
{
    using Baraka.API.DTO.Persisted.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Interface des configurations de DTO génériques.
    /// </summary>
    public interface IGenericJsonTypeConfiguration
    {
        /// <summary>
        ///     Retourne le nom littéral d'une clef rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type recherché.</param>
        /// <returns>Clef correspondante.</returns>
        string NameByType(Type type);
    }

    /// <summary>
    ///     Liste de correspondances clef/type applicables à un type
    ///     de DTO génériques persisté en JSON.
    /// </summary>
    /// <typeparam name="TBase">Type de base des objets sérialisés.</typeparam>
    /// <typeparam name="TKey">Type d'énumération.</typeparam>
    public class GenericJsonTypeConfiguration<TBase, TKey> : IGenericJsonTypeConfiguration
        where TBase : IGenericPersistedDTO
        where TKey : struct, IConvertible
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public GenericJsonTypeConfiguration()
        {
            if (!typeof(TKey).IsEnum)
            {
                throw new Error("Invalid enumeration type used to process generic JSON...");
            }

            TypeForKey = new Dictionary<TKey, Type>();
            KeyForType = new Dictionary<Type, TKey>();
        }

        /// <summary>
        ///     Dictionnaire de correspondances clef à type.
        /// </summary>
        public IDictionary<TKey, Type> TypeForKey { get; set; }

        /// <summary>
        ///     Dictionnaire de correspondances type à clef.
        /// </summary>
        public IDictionary<Type, TKey> KeyForType { get; set; }

        /// <summary>
        ///     Indique si la configuration contient un clef.
        /// </summary>
        /// <param name="key">Clef recherchée.</param>
        /// <returns>true si la clef est présente, false sinon.</returns>
        public bool HasKey(TKey key)
        {
            return TypeForKey.ContainsKey(key);
        }

        /// <summary>
        ///     Indique la configuration contient un type donné.
        /// </summary>
        /// <param name="type">Type recherché.</param>
        /// <returns>true si le type est présent, false sinon.</returns>
        public bool HasType(Type type)
        {
            return KeyForType.ContainsKey(type);
        }

        /// <summary>
        ///     Retourne le type rattaché à une clef donnée.
        /// </summary>
        /// <param name="key">Clef recherchée.</param>
        /// <returns>Type correspondant.</returns>
        public Type GetByKey(TKey key)
        {
            return TypeForKey[key];
        }

        /// <summary>
        ///     Retourne le type rattaché à une clef.
        /// </summary>
        /// <param name="type">Type recherché.</param>
        /// <returns>Clef correspondantes.</returns>
        public TKey GetByType(Type type)
        {
            return KeyForType[type];
        }

        /// <summary>
        ///     Retourne le nom littéral de la clef rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type de DTO.</param>
        /// <returns>Nom littéral.</returns>
        public string NameByType(Type type)
        {
            return Enum.GetName(typeof(TKey), GetByType(type));
        }

        /// <summary>
        ///     Ajoute le support pour un type final de DTO.
        /// </summary>
        /// <typeparam name="TFinal"></typeparam>
        /// <param name="key"></param>
        internal void AddType<TFinal>(TKey key) where TFinal : class, TBase
        {
            KeyForType.Add(typeof(TFinal), key);
            TypeForKey.Add(key, typeof(TFinal));
        }
    }
}
