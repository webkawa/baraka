namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Entities;
    using NHibernate;

    /// <summary>
    ///     DAO des champs.
    /// </summary>
    public class FieldDAO : AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        public FieldDAO(ISession session) : base(session)
        {
        }

        /// <summary>
        ///     Insère un champ dans la base de données.
        /// </summary>
        /// <param name="label">Libellé du champ.</param>
        /// <param name="code">Code d'accès.</param>
        /// <param name="table">Table rattachée.</param>
        /// <returns>Champ généré.</returns>
        public Field Insert(BundleDTO label, string code, Table table)
        {
            Field result = new Field()
            {
                Label = label,
                Code = code,
                Table = table
            };
            Session.Persist(result);
            return result;
        }
    }
}
