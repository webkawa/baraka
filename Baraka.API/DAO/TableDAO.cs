namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Tables;
    using Baraka.API.Entities;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Model;
    using NHibernate;
    using NHibernate.SqlCommand;
    using NHibernate.Transform;

    /// <summary>
    ///     DAO des tables.
    /// </summary>
    public class TableDAO : AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        public TableDAO(ISession session) : base(session)
        {
        }

        /// <summary>
        ///     Insère une table dans la base de données.
        /// </summary>
        /// <param name="table">Table insérée.</param>
        /// <returns>Table créée.</returns>
        public Table Insert(Table table)
        {
            GetValidator().Check(table);
            Session.Persist(table);
            return table;
        }

        /// <summary>
        ///     Réalise la mise à jour d'une table à partir d'un objet détaché.
        /// </summary>
        /// <param name="table">Objet détaché.</param>
        /// <returns>Objet mis à jour.</returns>
        public Table Update(Table table)
        {
            GetValidator().Check(table);
            return Session.Merge(table);
        }

        /// <summary>
        ///     Indique si un code de table est disponible pour l'insertion.
        /// </summary>
        /// <param name="code">Code évalué.</param>
        /// <returns>true si le code est disponible.</returns>
        public bool IsTableCodeAvailable(string code)
        {
            return Session
                .QueryOver<Table>()
                .Where(e => e.Code == code)
                .RowCount() == 0;
        }

        /// <summary>
        ///     Retourne la liste complète des tables en pré-chargeant les champs
        ///     et informations relatives.
        /// </summary>
        /// <returns>Liste complète des tables.</returns>
        public IList<Table> GetAllWithFields()
        {
            Table t = null;
            Field f = null;
            return Session
                .QueryOver(() => t)
                .JoinAlias(() => t.Fields, () => f, JoinType.LeftOuterJoin)
                .TransformUsing(Transformers.DistinctRootEntity)
                .List();
        }
    }
}
