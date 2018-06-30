namespace Baraka.API.DTO.Persisted.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Interface des DTO persistables.
    /// </summary>
    public interface IPersistedDTO
    {
    }

    /// <summary>
    ///     DTO enregistrable en base de données.
    /// </summary>
    [Serializable]
    public abstract class AbstractPersistedDTO : IPersistedDTO
    {
    }
}
