namespace Baraka.API.Internals.Persistence.Types
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Internals.Persistence.Serialization;
    using Newtonsoft.Json;
    using NHibernate;
    using NHibernate.Engine;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    ///     Type NHibernate adapté à l'enregistrement d'un DTO polyphorme
    ///     dans la base de donnée. 
    ///     Le type réel de l'objet est stocké, en mémoire, par deux dictionnaires
    ///     permettant la correspondance d'une clef à un type et vice-versa ;
    ///     en base de donnée, la valeur textuelle de la même clef permet d'indiquer
    ///     le type réel du DTO.
    /// </summary>
    /// <typeparam name="TBase">Type de base des objets sérialisés.</typeparam>
    /// <typeparam name="TKey">Type d'énumération.</typeparam>
    public class GenericJsonType<TBase, TKey> : AbstractJsonType<TBase>, IParameterizedType
        where TBase : IGenericPersistedDTO
        where TKey : struct, IConvertible
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="configuration">Actions de configuration.</param>
        public GenericJsonType()
        {
            if (!typeof(TKey).IsEnum)
            {
                throw new Error("Invalid enumeration type used to process generic JSON...");
            }

            KeyToType = new Dictionary<TKey, Type>();
            TypeToKey = new Dictionary<Type, TKey>();
        }

        /// <summary>
        ///     Type SQL des colonnes utilisées.
        /// </summary>
        public override SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[]
                {
                    new SqlType(DbType.StringFixedLength, 32),
                    new SqlType(DbType.String)
                };
            }
        }

        /// <summary>
        ///     Types supportés classés par clef.
        /// </summary>
        public IDictionary<TKey, Type> KeyToType { get; set; }

        /// <summary>
        ///     Clefs supportées par type.
        /// </summary>
        public IDictionary<Type, TKey> TypeToKey { get; set; }

        /// <summary>
        ///     Lit une valeur dans la base de données et procède à sa conversion dans le DTO cible.
        /// </summary>
        /// <param name="rs">Outil de lecture.</param>
        /// <param name="names">Colonnes SQL.</param>
        /// <param name="session">Session.</param>
        /// <param name="owner">Objet porteur.</param>
        /// <returns>Objet désérialisé.</returns>
        public override object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            try
            {
                // Lecture des paramètres
                TKey key = Enum.Parse<TKey>(rs[names[0]].ToString());
                string raw = rs[names[1]].ToString();

                // Recherche du type
                if (KeyToType.ContainsKey(key))
                {
                    return JsonConvert.DeserializeObject(
                        raw,
                        KeyToType[key],
                        new PersistentJsonSerializerSettings());
                }
                else
                {
                    throw new Error("Invalid key '{0}' found in database...", key);
                }
            }
            catch (Exception ex)
            {
                throw new Error(ex, "Generic JSON deserialization failure...");
            }
        }

        /// <summary>
        ///     Sérialise une valeur et l'enregistre dans la base de données.
        /// </summary>
        /// <param name="cmd">Outil d'écriture.</param>
        /// <param name="value">Valeur affectée.</param>
        /// <param name="index">Index.</param>
        /// <param name="session">Session.</param>
        public override void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            try
            {
                // Récupération de la source
                if (TypeToKey.ContainsKey(value.GetType()))
                {
                    // Récupération des objets
                    string key = Enum.GetName(typeof(TKey), TypeToKey[value.GetType()]);

                    // Création du paramètre type
                    var typeParameter = cmd.CreateParameter();
                    typeParameter.DbType = DbType.StringFixedLength;
                    typeParameter.Value = key;
                    cmd.Parameters[index] = typeParameter;

                    // Création du paramètre valeur
                    var dataParameter = cmd.CreateParameter();
                    dataParameter.DbType = DbType.String;
                    dataParameter.Value = JsonConvert.SerializeObject(
                        value,
                        new PersistentJsonSerializerSettings());
                    cmd.Parameters[index + 1] = dataParameter;
                }
                else
                {
                    throw new Error("Invalid type '{0}' passed to persist...", value.GetType());
                }
            }
            catch (Exception ex)
            {
                throw new Error(ex, "Generic JSON serialization failure...");
            }
        }

        /// <summary>
        ///     <see cref="IParameterizedType.SetParameterValues(IDictionary{string, string})" />
        /// </summary>
        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            GenericJsonTypeConfiguration<TBase, TKey> configuration = new GenericJsonTypeWrapper<TBase, TKey>(parameters["Data"]).Source;
            for (int i = 0; i < configuration.Keys.Count; i++)
            {
                KeyToType.Add(configuration.Keys[i], configuration.Types[i]);
                TypeToKey.Add(configuration.Types[i], configuration.Keys[i]);
            }
        }
    }

    /// <summary>
    ///     Configuration du type NHibernate pour les DTO polymorphes.
    /// </summary>
    /// <typeparam name="TBase">Type de base des objets sérialisés.</typeparam>
    /// <typeparam name="TKey">Type d'énumération.</typeparam>
    public class GenericJsonTypeConfiguration<TBase, TKey>
        where TBase : IGenericPersistedDTO
        where TKey : struct, IConvertible
    {
        /// <summary>
        ///     Clefs dans l'ordre.
        /// </summary>
        public IList<TKey> Keys { get; set; } = new List<TKey>();

        /// <summary>
        ///     Types dans l'ordre.
        /// </summary>
        public IList<Type> Types { get; set; } = new List<Type>();

        /// <summary>
        ///     Ajoute le support pour un type final de DTO.
        /// </summary>
        /// <typeparam name="TFinal"></typeparam>
        /// <param name="key"></param>
        internal void AddType<TFinal>(TKey key) where TFinal : class, TBase
        {
            Keys.Add(key);
            Types.Add(typeof(TFinal));
        }
    }

    /// <summary>
    ///     Enveloppe des configurations pour les DTO polymorphes persistents.
    /// </summary>
    /// <typeparam name="TBase">Type de base des objets sérialisés.</typeparam>
    /// <typeparam name="TKey">Type d'énumération.</typeparam>
    public class GenericJsonTypeWrapper<TBase, TKey>
        where TBase : IGenericPersistedDTO
        where TKey : struct, IConvertible
    {
        /// <summary>
        ///     Données.
        ///     Ne pas renommer le champ.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        ///     Source.
        /// </summary>
        public GenericJsonTypeConfiguration<TBase, TKey> Source { get; set; }

        /// <summary>
        ///     Constructeur par source.
        /// </summary>
        /// <param name="source">Configuration source.</param>
        public GenericJsonTypeWrapper(GenericJsonTypeConfiguration<TBase, TKey> source)
        {
            Data = JsonConvert.SerializeObject(source);
            Source = source;
        }

        /// <summary>
        ///     Constructeur par flux.
        /// </summary>
        /// <param name="data">Données sources.</param>
        public GenericJsonTypeWrapper(string data)
        {
            Data = data;
            Source = JsonConvert.DeserializeObject<GenericJsonTypeConfiguration<TBase, TKey>>(data);
        }
    }
}
