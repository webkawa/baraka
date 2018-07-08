namespace Baraka.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes;

    /// <summary>
    ///     Contrôleur des tables.
    /// </summary>
    public class TableController
    {
        /// <summary>
        ///     Retourne la liste complète des tables.
        /// </summary>
        /// <returns>Liste des tables.</returns>
        [Authenticate]
        [Route("services/tables/list")]
        public IList<Table> GetTables(
            [FromServices] TableDAO tableDAO)
        {
            return tableDAO.GetAllWithFields();
        }

        /// <summary>
        ///     Ajoute une table dans la base.
        /// </summary>
        /// <param name="add">Table à créer.</param>
        /// <param name="tableDAO">DAO des tables.</param>
        /// <returns>Liste des tables après ajout.</returns>
        [Authenticate]
        [Route("services/tables/add")]
        [Transactional]
        public IList<Table> AddTable(
            [FromBody] Table add,
            [FromServices] TableDAO tableDAO)
        {
            tableDAO.Insert(add.Label, add.Code);
            return GetTables(tableDAO);
        }
    }
}
