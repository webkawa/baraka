namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Fields;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Internals.Attributes.Validators;

    /// <summary>
    ///     Liste des typologies de champs.
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        ///     Chaîne de caractères.
        /// </summary>
        STRING = 1,

        /// <summary>
        ///     Champ booléen.
        /// </summary>
        BOOLEAN = 2,

        /// <summary>
        ///     Champ numérique.
        /// </summary>
        NUMERIC = 3,

        /// <summary>
        ///     Date.
        /// </summary>
        DATE = 4,

        /// <summary>
        ///     Référence vers une table tierce.
        /// </summary>
        REFERENCE = 99
    }

    /// <summary>
    ///     Champ rattaché à une table métier.
    /// </summary>
    public class Field : Entity
    {
        /// <summary>
        ///     Libellé de la table.
        /// </summary>
        [Required]
        public virtual BundleDTO Label { get; set; }

        /// <summary>
        ///     Code d'accès.
        /// </summary>
        [Required]
        [MinLength(3)]
        [RegularExpression("[a-z0-9_]+")]
        public virtual string Code { get; set; }

        /// <summary>
        ///     Configuration du champ.
        /// </summary>
        [Required]
        public virtual AbstractFieldConfigurationDTO Configuration { get; set; }

        /// <summary>
        ///     Table d'appartenance.
        /// </summary>
        [Required]
        public virtual Table Table { get; set; }
    }

    /// <summary>
    ///     Classe de mappage des champs.
    /// </summary>
    public class FieldMapping : EntityMapping<Field>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public FieldMapping()
        {
            PropertyJsonFixed(e => e.Label);
            Property(e => e.Code);
            PropertyJsonGeneric<AbstractFieldConfigurationDTO, FieldType>(
                e => e.Configuration, 
                cfg =>
                {
                    cfg.AddType<BooleanFieldConfigurationDTO>(FieldType.BOOLEAN);
                    cfg.AddType<DateFieldConfigurationDTO>(FieldType.DATE);
                    cfg.AddType<NumericFieldConfigurationDTO>(FieldType.NUMERIC);
                    cfg.AddType<ReferenceFieldConfigurationDTO>(FieldType.REFERENCE);
                    cfg.AddType<StringFieldConfigurationDTO>(FieldType.STRING);
                });
            ManyToOne(e => e.Table);
        }
    }
}
