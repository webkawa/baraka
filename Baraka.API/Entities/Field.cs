namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Shared;

    /// <summary>
    ///     Champ rattaché à une table métier.
    /// </summary>
    public class Field : Entity
    {
        /// <summary>
        ///     Libellé de la table.
        /// </summary>
        public virtual BundleDTO Label { get; set; }

        /// <summary>
        ///     Code d'accès.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     Table d'appartenance.
        /// </summary>
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
            ManyToOne(e => e.Table);
        }
    }
}
