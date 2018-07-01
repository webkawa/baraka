namespace Baraka.API.DTO.Persisted.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    /// <summary>
    ///     Interface des DTO persistables.
    /// </summary>
    public interface IPersistedDTO
    {
        /// <summary>
        ///     Réalise une copie profonde de l'objet.
        /// </summary>
        /// <returns>Copie profonde.</returns>
        IPersistedDTO DeepCopy();
    }

    /// <summary>
    ///     DTO enregistrable en base de données.
    /// </summary>
    public abstract class AbstractPersistedDTO : IPersistedDTO
    {
        /// <summary>
        ///     Réalise une copie profonde de l'objet.
        /// </summary>
        /// <returns>Copie profonde.</returns>
        public IPersistedDTO DeepCopy()
        {
            try
            {
                IPersistedDTO copy = Activator.CreateInstance(GetType()) as IPersistedDTO;
                foreach (PropertyInfo pi in GetType().GetProperties())
                {
                    if (typeof(IPersistedDTO).IsAssignableFrom(pi.PropertyType))
                    {
                        // Copie profonde
                        IPersistedDTO subcopy = (pi.GetValue(this, null) as IPersistedDTO).DeepCopy();
                        pi.SetValue(copy, subcopy, null);
                    }
                    else
                    {
                        // Copie par référence
                        object subcopy = pi.GetValue(this, null);
                        pi.SetValue(copy, subcopy, null);
                    }
                }
                
                return copy;
            }
            catch (Exception ex)
            {
                throw new Error(ex, "Unable to deep-copy persited DTO of type '{0}'...", GetType());
            }
        }
    }
}
