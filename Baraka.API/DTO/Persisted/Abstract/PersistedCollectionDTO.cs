namespace Baraka.API.DTO.Persisted.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.Entities;
    using NHibernate;

    /// <summary>
    ///     Interface des collections persistées.
    /// </summary>
    public interface IPersistedCollectionDTO : IPersistedDTO
    {
        /// <summary>
        ///     Liste des identifiants.
        /// </summary>
        ISet<Guid> Ids { get; set; }
    }

    /// <summary>
    ///     Collection persistée.
    ///     Objet descriptif d'une collection vers plusieurs entités déclarée à l'intérieur
    ///     d'un DTO persisté, au format JSON, dans la base de données.
    /// </summary>
    /// <typeparam name="TEntity">Type d'entité ciblée.</typeparam>
    public class PersistedCollectionDTO<TEntity> : IPersistedCollectionDTO
        where TEntity : Entity
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PersistedCollectionDTO()
        {
            Ids = new HashSet<Guid>();
        }

        /// <summary>
        ///     Liste des identifiants.
        /// </summary>
        public ISet<Guid> Ids { get; set; }
        
        /// <summary>
        ///     Affectation directe d'une liste d'entités dans la collection.
        /// </summary>
        /// <param name="entities">Entités affectées.</param>
        public static implicit operator PersistedCollectionDTO<TEntity>(TEntity[] entities)
        {
            var result = new PersistedCollectionDTO<TEntity>();
            foreach (TEntity entity in entities)
            {
                result.Add(entity);
            }

            return result;
        }

        /// <summary>
        ///     Procède à la copie de la référence.
        /// </summary>
        /// <returns>Référence copiée.</returns>
        public IPersistedDTO DeepCopy()
        {
            return new PersistedCollectionDTO<TEntity>()
            {
                Ids = new HashSet<Guid>(Ids)
            };
        }

        /// <summary>
        ///     Méthode de récupération des entités.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        /// <returns>Entité récupérée.</returns>
        internal IList<TEntity> Get(ISession session)
        {
            IList<TEntity> result = new List<TEntity>();
            foreach (Guid id in Ids.ToArray())
            {
                TEntity entity = session.Get<TEntity>(id);
                if (entity == null)
                {
                    Ids.Remove(id);
                }
                else
                {
                    result.Add(entity);
                }
            }

            return result;
        }

        /// <summary>
        ///     Ajoute une entité dans la collection.
        /// </summary>
        /// <param name="entity">Entité ajoutée.</param>
        internal void Add(TEntity entity)
        {
            if (entity?.Id == null)
            {
                throw new Error("No ID defined on entity to add...");
            }
            else
            {
                Ids.Add(entity.Id);
            }
        }

        /// <summary>
        ///     Retire une entité de la collection.
        /// </summary>
        /// <param name="entity">Entité retirée.</param>
        internal void Remove(TEntity entity)
        {

            if (entity?.Id == null)
            {
                throw new Error("No ID defined on entity to remove...");
            }
            else
            {
                Ids.Remove(entity.Id);
            }
        }
    }
}
