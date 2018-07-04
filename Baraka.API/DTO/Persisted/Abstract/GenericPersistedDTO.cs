namespace Baraka.API.DTO.Persisted.Abstract
{
    using Baraka.API.Internals.Persistence.Serialization.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Interface des DTO enregistrables de type générique.
    /// </summary>
    public interface IGenericPersistedDTO : IPersistedDTO
    {
        /// <summary>
        ///     Type du DTO.
        /// </summary>
        string Type { get; }
    }

    /// <summary>
    ///     DTO à type générique enregistrable en base de données.
    /// </summary>
    public abstract class GenericPersistedDTO : AbstractPersistedDTO, IGenericPersistedDTO
    {
        /// <summary>
        ///     Type du DTO.
        /// </summary>
        public string Type
        {
            get
            {
                return GenericJsonTypeIndex
                    .GetConfiguration(GetType())
                    .NameByType(GetType());
            }
        }
    }
}
