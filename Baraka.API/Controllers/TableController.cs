namespace Baraka.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes.Mvc;
    using Baraka.API.Exceptions;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    ///     Contrôleur des tables.
    /// </summary>
    public class TableController
    {
        /// <summary>
        ///     Retourne la liste complète des tables.
        /// </summary>
        /// <returns>Liste des tables.</returns>
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
        [Transactional]
        [Route("services/tables/add")]
        public Table AddTable(
            [FromBody] Table add,
            [FromServices] TableDAO tableDAO)
        {
            return tableDAO.Insert(add.Label, add.Code);
        }

        /// <summary>
        ///     Service de vérification de disponibilité d'un code de table.
        /// </summary>
        /// <param name="code">Code évalué.</param>
        /// <param name="tableDAO">DAO des tables.</param>
        /// <returns>true si le code existe déjà, false sinon.</returns>
        [Route("services/tables/check-code")]
        public bool CheckTableCode(
            [FromQuery] string code,
            [FromServices] TableDAO tableDAO)
        {
            return tableDAO.IsCodeAvailable(code);
        }
    }
}
