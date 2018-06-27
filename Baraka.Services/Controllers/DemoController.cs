namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Internals.Attributes;
    using Microsoft.AspNetCore.Mvc;
    using NHibernate;
    using NLog;

    /// <summary>
    ///     Services liées à l'initialisation de l'application.
    /// </summary>
    public class DemoController
    {
        /// <summary>
        ///     Génération des données de démonstration.
        /// </summary>
        /// <param name="userDAO">DAO des utilisateurs.</param>
        [Route("/demo")]
        [Transactional]
        public string Demo([FromServices] UserDAO userDAO)
        {
            userDAO.Insert("kawa", "kawa");
            return "ok";
        }
    }
}
