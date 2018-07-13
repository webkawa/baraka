namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Tables;
    using Baraka.API.Internals.Attributes.Validators;
    using Baraka.API.Internals.Persistence.Types;

    /// <summary>
    ///     Table constitutive de la base métier.
    /// </summary>
    public class Table : Entity
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public Table()
        {
            Fields = new HashSet<Field>();
        }

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
        [UniqueTableCode]
        public virtual string Code { get; set; }

        /// <summary>
        ///     Configuration.
        /// </summary>
        [Required]
        public virtual TableConfigurationDTO Configuration { get; set; }

        /// <summary>
        ///     Liste des champs.
        /// </summary>
        public virtual ISet<Field> Fields { get; set; }
    }

    /// <summary>
    ///     Mappage des tables.
    /// </summary>
    public class TableMapping : EntityMapping<Table>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public TableMapping()
        {
            PropertyJsonFixed(e => e.Label);
            Property(e => e.Code);
            PropertyJsonFixed(e => e.Configuration);
            OneToMany(e => e.Fields);
        }
    }
}
