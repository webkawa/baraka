namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Champ rattaché à une table métier.
    /// </summary>
    public class Field : Entity
    {
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
            ManyToOne(e => e.Table);
        }
    }
}
