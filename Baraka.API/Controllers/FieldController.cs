namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes.Mvc;
    using Microsoft.AspNetCore.Mvc;
    using NHibernate;

    /// <summary>
    ///     Contrôleur des champs.
    /// </summary>
    public class FieldController
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="fieldDAO">DAO des champs.</param>
        public FieldController(FieldDAO fieldDAO)
        {
            FieldDAO = fieldDAO;
        }

        /// <summary>
        ///     DAO des champs.
        /// </summary>
        private FieldDAO FieldDAO { get; set; }

        /// <summary>
        ///     Ajoute un champ rattaché à une table.
        /// </summary>
        /// <param name="field">Champ rajouté.</param>
        /// <returns>Champ rajouté.</returns>
        [Transactional]
        [Route("services/fields/add")]
        public Field AddField([FromBody] Field field)
        {
            return FieldDAO.Insert(field);
        }

        /// <summary>
        ///     Met à jour un champ rattaché à une table.
        /// </summary>
        /// <param name="field">Champ rajouté.</param>
        /// <returns>Champ rajouté.</returns>
        [Transactional]
        [Route("services/fields/update")]
        public Field UpdateField([FromBody] Field field)
        {
            return FieldDAO.Update(field);
        }

        /// <summary>
        ///     Service de vérification de disponibilité d'un code de champ.
        /// </summary>
        /// <param name="table">Identifiant de la table liée.</param>
        /// <param name="code">Code évalué.</param>
        /// <param name="session">Session NHibernate.</param>
        /// <returns>true si le code n'existe pas, false sinon.</returns>
        [Route("services/fields/check-code")]
        public bool CheckFieldCode(
            [FromQuery] Guid table,
            [FromQuery] string code,
            [FromServices] ISession session)
        {
            return !session.Get<Table>(table).Fields.Any(e => e.Code == code);
        }
    }
}
