namespace Baraka.API.Internals.Persistence.Types
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.DTO.Persisted.Shared;
    using NHibernate.Engine;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;

    /// <summary>
    ///     Type NHibernate dédié au stockage d'une chaîne de caractères
    ///     au format JSON par l'intermédiaire d'un DTO cible, simple ou
    ///     polymorphe.
    /// </summary>
    public abstract class AbstractJsonType<TObject> : IUserType
        where TObject : IPersistedDTO
    {
        /// <summary>
        ///     <see cref="IUserType.IsMutable" />
        /// </summary>
        public bool IsMutable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///     <see cref="IUserType.ReturnedType" />
        /// </summary>
        public Type ReturnedType
        {
            get
            {
                return typeof(TObject);
            }
        }

        /// <summary>
        ///     <see cref="IUserType.SqlTypes" />
        /// </summary>
        public abstract SqlType[] SqlTypes { get; }

        /// <summary>
        ///     <see cref="IUserType.DeepCopy(object)" />
        /// </summary>
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
        ///     <see cref="IUserType.Assemble(object, object)" />
        /// </summary>
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }

        /// <summary>
        ///     <see cref="IUserType.Disassemble(object)" />
        /// </summary>
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }

        /// <summary>
        ///     <see cref="IUserType.Replace(object, object, object)" />
        /// </summary>
        public object Replace(object original, object target, object owner)
        {
            return DeepCopy(original);
        }

        /// <summary>
        ///     <see cref="IUserType.Equals(object, object)" />
        /// </summary>
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
        ///     <see cref="IUserType.GetHashCode(object)" />
        /// </summary>
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        /// <summary>
        ///     <see cref="IUserType.NullSafeSet(DbCommand, object, int, ISessionImplementor)" />
        /// </summary>
        public abstract object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner);

        /// <summary>
        ///     <see cref="IUserType.NullSafeGet(DbDataReader, string[], ISessionImplementor, object)" />
        /// </summary>
        public abstract void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session);
    }
}
