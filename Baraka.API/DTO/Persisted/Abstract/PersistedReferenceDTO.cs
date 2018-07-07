namespace Baraka.API.DTO.Persisted.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Entities;
    using Baraka.API.Exceptions;
    using NHibernate;

    /// <summary>
    ///     Interface des références persistées.
    /// </summary>
    public interface IPersistedReferenceDTO : IPersistedDTO
    {
        /// <summary>
        ///     Identifiant.
        /// </summary>
        Guid? Id { get; set; }
    }

    /// <summary>
    ///     Référence persistée.
    ///     Objet descriptif d'une référence vers une entité déclarée à l'intérieur
    ///     d'un DTO persisté, au format JSON, dans la base de données.
    /// </summary>
    /// <typeparam name="TEntity">Type d'entité ciblée.</typeparam>
    public class PersistedReferenceDTO<TEntity> : IPersistedReferenceDTO
        where TEntity : Entity
    {
        /// <summary>
        ///     Identifiant.
        /// </summary>
        public Guid? Id { get; set; }
        
        /// <summary>
        ///     Affectation directe d'une entité dans la référence.
        /// </summary>
        /// <param name="entity">Entité affectée.</param>
        public static implicit operator PersistedReferenceDTO<TEntity>(TEntity entity)
        {
            var result = new PersistedReferenceDTO<TEntity>();
            result.Set(entity);
            return result;
        }

        /// <summary>
        ///     Procède à la copie de la référence.
        /// </summary>
        /// <returns>Référence copiée.</returns>
        public IPersistedDTO DeepCopy()
        {
            return new PersistedReferenceDTO<TEntity>()
            {
                Id = Id
            };
        }

        /// <summary>
        ///     Méthode de récupération de l'entité.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        /// <returns>Entité récupérée.</returns>
        internal TEntity Get(ISession session)
        {
            TEntity result = session.Get<TEntity>(Id);
            if (result == null)
            {
                Id = null;
            }

            return result;
        }

        /// <summary>
        ///     Méthode d'affectation de l'entité.
        /// </summary>
        /// <param name="value">Entité affectée.</param>
        internal void Set(TEntity value)
        {
            if (value?.Id == null)
            {
                throw new InternalException("No ID defined on entity...");
            }
            else
            {
                Id = value.Id;
            }
        }
    }
}
