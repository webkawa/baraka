namespace Baraka.API.Internals.Persistence.Serialization.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.Exceptions;

    /// <summary>
    ///     Interface des configurations de DTO génériques.
    /// </summary>
    public interface IGenericJsonTypeConfiguration
    {
        /// <summary>
        ///     Type de clef.
        /// </summary>
        Type KeyType { get; }

        /// <summary>
        ///     Retourne le type rattaché à un clef non-typée.
        /// </summary>
        /// <param name="key">Clef recherchée.</param>
        /// <returns>Type correspondant.</returns>
        Type UnsafeGetByKey(object key);

        /// <summary>
        ///     Retourne une instance d'objet liée à une clef non-typée.
        /// </summary>
        /// <returns>Instance de l'objet.</returns>
        IGenericPersistedDTO UnsafeGetInstance(object key);

        /// <summary>
        ///     Retourne le nom littéral d'une clef rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type recherché.</param>
        /// <returns>Clef correspondante.</returns>
        string UnsafeGetNameByType(Type type);
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
                throw new InternalException("Invalid enumeration type used to process generic JSON...");
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
        ///     Type des clefs.
        /// </summary>
        public Type KeyType
        {
            get
            {
                return typeof(TKey);
            }
        }

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
        ///     Retourne une instance d'objet liée à une clef non-typée.
        /// </summary>
        /// <returns>Instance de l'objet.</returns>
        public IGenericPersistedDTO UnsafeGetInstance(object key)
        {
            return Activator.CreateInstance(UnsafeGetByKey(key)) as IGenericPersistedDTO;
        }

        /// <summary>
        ///     Retourne le type rattaché à un clef non-typée.
        /// </summary>
        /// <param name="key">Clef recherchée.</param>
        /// <returns>Type correspondant.</returns>
        public Type UnsafeGetByKey(object key)
        {
            TKey typed = (TKey)key;
            if (key == null)
            {
                throw new InternalException("Invalid key type '{0}'", key);
            }

            return TypeForKey[typed];
        }

        /// <summary>
        ///     Retourne le nom littéral de la clef rattachée à un type de DTO.
        /// </summary>
        /// <param name="type">Type de DTO.</param>
        /// <returns>Nom littéral.</returns>
        public string UnsafeGetNameByType(Type type)
        {
            return Enum.GetName(typeof(TKey), GetByType(type));
        }

        /// <summary>
        ///     Ajoute le support pour un type final de DTO.
        /// </summary>
        /// <typeparam name="TFinal"></typeparam>
        /// <param name="key"></param>
        internal void AddType<TFinal>(TKey key) 
            where TFinal : class, TBase, new()
        {
            KeyForType.Add(typeof(TFinal), key);
            TypeForKey.Add(key, typeof(TFinal));
        }
    }
}
