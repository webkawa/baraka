namespace Baraka.API.Internals.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    using Newtonsoft.Json;
    using NHibernate.Engine;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    ///     Type SQL adapté à la sérialisation et désérialisation à la volée
    ///     d'un DTO vers le format JSON (via "Newtonsoft.JSON").
    /// </summary>
    /// <typeparam name="TObject">Type d'objet sérialisé.</typeparam>
    internal class JsonType<TObject> : IUserType
        where TObject : class, new()
    {
        /// <summary>
        ///     Type de la colonne SQL.
        /// </summary>
        public SqlType[] SqlTypes
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
        ///     Type de retour.
        /// </summary>
        public Type ReturnedType
        {
            get
            {
                return typeof(TObject);
            }
        }

        /// <summary>
        ///     Indique si l'objet est mutable.
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///     Assemble l'objet à partir d'une représentation en cache.
        /// </summary>
        /// <param name="cached">Objet issu du cache.<param>
        /// <param name="owner">Objet porteur.</param>
        /// <returns>Copie de l'objet.</returns>
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        /// <summary>
        ///     Prépare une copie de l'objet pouvant être placée dans le cache.
        /// </summary>
        /// <param name="value">Valeur à placer dans le cache.</param>
        /// <returns>Copie de l'objet.</returns>
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

        /// <summary>
        ///     Lit une valeur dans la base de données et procède à sa conversion dans le DTO cible.
        /// </summary>
        /// <param name="rs">Outil de lecture.</param>
        /// <param name="names">Colonnes SQL.</param>
        /// <param name="session">Session.</param>
        /// <param name="owner">Objet porteur.</param>
        /// <returns>Objet désérialisé.</returns>
        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            string raw = rs.GetString(0);
            return JsonConvert.DeserializeObject<TObject>(raw);
        }

        /// <summary>
        ///     Sérialise une valeur et l'enregistre dans la base de données.
        /// </summary>
        /// <param name="cmd">Outil d'écriture.</param>
        /// <param name="value">Valeur affectée.</param>
        /// <param name="index">Index.</param>
        /// <param name="session">Session.</param>
        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            var parameter = cmd.CreateParameter();
            parameter.DbType = DbType.String;
            parameter.Value = JsonConvert.SerializeObject(value as TObject);
            cmd.Parameters[index] = parameter;
        }

        /// <summary>
        ///     Réalise une copie profonde de l'objet.
        /// </summary>
        /// <param name="value">Instance traitée.</param>
        /// <returns>Instance copiée.</returns>
        public object DeepCopy(object value)
        {
            // Voir : https://www.c-sharpcorner.com/UploadFile/ff2f08/deep-copy-of-object-in-C-Sharp/
            using (MemoryStream stream = new MemoryStream())
            {
                if (value.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, value);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }

                throw new NotImplementedException("Unable to deep copy object");
            }
        }

        /// <summary>
        ///     Réalise au remplacement d'un objet dans le cas d'une fusion.
        /// </summary>
        /// <param name="original">Objet d'origine.</param>
        /// <param name="target">Objet cible.</param>
        /// <param name="owner">Objet porteur.</param>
        /// <returns>Objet fusionné.</returns>
        public object Replace(object original, object target, object owner)
        {
            return DeepCopy(original);
        }

        /// <summary>
        ///     Indique si deux objets du type sont égaux.
        /// </summary>
        /// <param name="x">Objet gauche.</param>
        /// <param name="y">Objet droit.</param>
        /// <returns>true si les deux objets sont égaux.</returns>
        public new bool Equals(object x, object y)
        {
            if (x == null)
            {
                return y == null;
            }
            else
            {
                return x.Equals(y);
            }
        }

        /// <summary>
        ///     Retourne le code de hachage rattaché à un objet.
        /// </summary>
        /// <param name="x">Objet ciblé.</param>
        /// <returns>Code de hachage.</returns>
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    }
}
