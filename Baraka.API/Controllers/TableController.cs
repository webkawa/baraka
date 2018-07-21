namespace Baraka.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes.Mvc;
    using Baraka.API.Exceptions;
    using System.IO;
    using Newtonsoft.Json;
    using Baraka.API.DTO.Persisted.Tables;
    using NHibernate;
    using System.Linq;
    using Baraka.API.Internals.Model;
    using Remotion.Linq;
    using Remotion.Linq.Clauses;
    using Remotion.Linq.Parsing;

    /// <summary>
    ///     Contrôleur des tables.
    /// </summary>
    public class TableController
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="dao">DAO des tables.</param>
        public TableController(TableDAO dao)
        {
            TableDAO = dao;
        }

        /// <summary>
        ///     DAO des tables.
        /// </summary>
        private TableDAO TableDAO { get; set; }

        /// <summary>
        ///     Retourne la liste complète des tables.
        /// </summary>
        /// <returns>Liste des tables.</returns>
        [Route("services/tables/list")]
        public IList<Table> GetTables()
        {
            return TableDAO.GetAllWithFields();
        }

        /// <summary>
        ///     Ajoute une table dans la base.
        /// </summary>
        /// <param name="table">Table à créer.</param>
        /// <returns>Liste des tables après ajout.</returns>
        [Transactional]
        [Route("services/tables/add")]
        public Table AddTable([FromBody] Table table)
        {
            return TableDAO.Insert(table);
        }

        /// <summary>
        ///     Met à jour une table.
        /// </summary>
        /// <param name="table">Objet porteur des mises à jour.</param>
        /// <returns>Objet mis à jour.</returns>
        [Transactional]
        [Route("services/tables/update")]
        public Table UpdateTable([FromBody] Table table)
        {
            return TableDAO.Update(table);
        }

        /// <summary>
        ///     Service de vérification de disponibilité d'un code de table.
        /// </summary>
        /// <param name="code">Code évalué.</param>
        /// <returns>true si le code n'existe pas, false sinon.</returns>
        [Route("services/tables/check-code")]
        public bool CheckTableCode([FromQuery] string code)
        {
            return TableDAO.IsTableCodeAvailable(code);
        }
    }
}
