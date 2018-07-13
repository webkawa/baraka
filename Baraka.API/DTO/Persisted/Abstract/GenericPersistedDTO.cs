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
    }

    /// <summary>
    ///     DTO à type générique enregistrable en base de données.
    /// </summary>
    public abstract class GenericPersistedDTO : AbstractPersistedDTO, IGenericPersistedDTO
    {
    }
}
