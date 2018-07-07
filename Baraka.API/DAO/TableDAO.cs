namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Entities;
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
        /// <param name="label">Libellé de la table.</param>
        /// <param name="code">Code d'accès.</param>
        /// <returns>Table créée.</returns>
        public Table Insert(BundleDTO label, string code)
        {
            Table result = new Table()
            {
                Label = label,
                Code = code
            };
            Session.Persist(result);
            return result;
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
