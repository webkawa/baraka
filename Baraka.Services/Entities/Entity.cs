namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;

    /// <summary>
    ///     Entité.
    ///     Classe abstraite descriptive d'une entité mappée par le biais 
    ///     de NHibernate.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        ///     Identifiant.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        ///     Date de création.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Date de mise à jour.
        /// </summary>
        public virtual DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    ///     Classe de mappage des entités.
    /// </summary>
    /// <typeparam name="TEntity">Type d'entité mappée.</typeparam>
    public abstract class EntityMapping<TEntity> : ClassMapping<TEntity> where TEntity : Entity
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public EntityMapping()
        {
            Id(
                e => e.Id, 
                m =>
                {
                    m.Generator(Generators.GuidComb);
                });
            Property(e => e.CreatedAt);
            Property(e => e.UpdatedAt);
        }
    }
}
