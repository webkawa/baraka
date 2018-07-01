namespace Baraka.API.DTO.Persisted.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Interface des DTO enregistrables de type fixe.
    /// </summary>
    public interface IFixedPersistedDTO : IPersistedDTO
    {
    }

    /// <summary>
    ///     DTO à type fixe enregistrable en base de données.
    /// </summary>
    public abstract class FixedPersistedDTO : AbstractPersistedDTO, IFixedPersistedDTO
    {
    }
}
