namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            Bag(
                e => e.Fields,
                m => { },
                o => o.OneToMany());
        }
    }
}
