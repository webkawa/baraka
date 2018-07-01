namespace Baraka.API.Internals.Persistence.Types
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Internals.Persistence.Serialization;
    using Newtonsoft.Json;
    using NHibernate.Engine;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    ///     Type NHibernate adapté à la sérialisation d'un DTO fixe (non-polyphorme)
    ///     dans une base de données.
    /// </summary>
    /// <typeparam name="TObject">Type d'objet sérialisé.</typeparam>
    public class FixedJsonType<TObject> : AbstractJsonType<TObject>
        where TObject : class, IFixedPersistedDTO
    {
        /// <summary>
        ///     Type de la colonne SQL.
        /// </summary>
        public override SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[]
                {
                    new SqlType(DbType.String)
                };
            }
        }

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
            string raw = rs[names[0]].ToString();
            return JsonConvert.DeserializeObject<TObject>(
                raw,
                new PersistentJsonSerializerSettings());
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
            var parameter = cmd.CreateParameter();
            parameter.DbType = DbType.String;
            parameter.Value = JsonConvert.SerializeObject(
                value as TObject,
                new PersistentJsonSerializerSettings());
            cmd.Parameters[index] = parameter;
        }
    }
}
