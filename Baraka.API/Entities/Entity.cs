namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Abstract;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Internals.Persistence.Serialization.Configuration;
    using Baraka.API.Internals.Persistence.Types;
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

        /// <summary>
        ///     Mappage d'un DTO sérialisable au format JSON.
        /// </summary>
        /// <typeparam name="TProperty">Type de DTO sérialisé.</typeparam>
        /// <param name="property">Propriété mappée.</param>
        /// <param name="configuration">Actions de configuration.</param>
        protected void PropertyJsonFixed<TProperty>(Expression<Func<TEntity, TProperty>> property, Action<IPropertyMapper> configuration = null)
            where TProperty : class, IFixedPersistedDTO
        {
            Property(
                property,
                mapper =>
                {
                    mapper.Type<FixedJsonType<TProperty>>();
                    configuration?.Invoke(mapper);
                });
        }

        /// <summary>
        ///     Mappage d'un DTO polymorphe sérialisable au format JSON.
        /// </summary>
        /// <typeparam name="TProperty">Type de DTO base.</typeparam>
        /// <typeparam name="TKey">Type de clef utilisée.</typeparam>
        /// <param name="property">Propriété mappée.</param>
        /// <param name="types">Liste des types supportés.</param>
        /// <param name="configuration">Actions de configuration.</param>
        protected void PropertyJsonGeneric<TProperty, TKey>(Expression<Func<TEntity, TProperty>> property, Action<GenericJsonTypeConfiguration<TProperty, TKey>> types, Action<IPropertyMapper> configuration = null)
            where TProperty : IGenericPersistedDTO
            where TKey : struct, IConvertible
        {
            Property(
                property,
                mapper =>
                {
                    // Création de la configuration
                    var inner = new GenericJsonTypeConfiguration<TProperty, TKey>();
                    types(inner);

                    // Référencement
                    GenericJsonTypeIndex.AddConfiguration<TProperty>(inner);

                    // Création de l'enveloppe
                    var wrapper = new GenericJsonTypeWrapper<TProperty, TKey>(inner);

                    // Paramétrage
                    mapper.Type<GenericJsonType<TProperty, TKey>>(wrapper);
                    mapper.Columns(
                        type =>
                        {
                            type.Name(
                                string.Concat(
                                    (property.Body as MemberExpression).Member.Name,
                                    "_type"));
                        }, 
                        dto =>
                        {
                            dto.Name(
                                string.Concat(
                                    (property.Body as MemberExpression).Member.Name,
                                    "_data"));
                        });

                    configuration?.Invoke(mapper);
                });
        }

        /// <summary>
        ///     Mappage d'une liste ("OneToMany") standardisée.
        /// </summary>
        /// <typeparam name="TDestination">Type de l'entité de destination.</typeparam>
        /// <param name="property">Collection de mappage.</param>
        /// <param name="configuration">Actions de configuration.</param>
        protected void OneToMany<TDestination>(
            Expression<Func<TEntity, IEnumerable<TDestination>>> property, 
            Action<ISetPropertiesMapper<TEntity, TDestination>> configuration = null) 
            where TDestination : Entity
        {
            Set(
                property,
                mapping =>
                {
                    mapping.Inverse(true);
                    configuration?.Invoke(mapping);
                },
                o => o.OneToMany());
        }
    }
}
