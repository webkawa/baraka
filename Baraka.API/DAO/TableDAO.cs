namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Entities;
    using NHibernate;

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
    }
}
