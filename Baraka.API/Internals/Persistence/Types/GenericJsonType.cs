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
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Persistence.Serialization;
    using Baraka.API.Internals.Persistence.Serialization.Configuration;
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
        public GenericJsonType()
        {
            Configuration = new GenericJsonTypeConfiguration<TBase, TKey>();
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
        ///     Configuration.
        /// </summary>
        public GenericJsonTypeConfiguration<TBase, TKey> Configuration { get; set; }

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
                if (Configuration.HasKey(key))
                {
                    return JsonConvert.DeserializeObject(
                        raw,
                        Configuration.GetByKey(key),
                        Settings);
                }
                else
                {
                    throw new InternalException("Invalid key '{0}' found in database...", key);
                }
            }
            catch (Exception ex)
            {
                throw new InternalException(ex, "Generic JSON deserialization failure...");
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
                if (Configuration.HasType(value.GetType()))
                {
                    // Récupération des objets
                    string key = Configuration.UnsafeGetNameByType(value.GetType());

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
                        Settings);
                    cmd.Parameters[index + 1] = dataParameter;
                }
                else
                {
                    throw new InternalException("Invalid type '{0}' passed to persist...", value.GetType());
                }
            }
            catch (Exception ex)
            {
                throw new InternalException(ex, "Generic JSON serialization failure...");
            }
        }

        /// <summary>
        ///     <see cref="IParameterizedType.SetParameterValues(IDictionary{string, string})" />
        /// </summary>
        public void SetParameterValues(IDictionary<string, string> parameters)
        {
            Configuration = new GenericJsonTypeWrapper<TBase, TKey>(parameters["Data"]).Source;
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
