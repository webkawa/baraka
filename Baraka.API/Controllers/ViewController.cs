namespace Baraka.API.Controllers
{
    using Baraka.API.DAO;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes;
    using Baraka.API.Internals.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Contrôleur des vues.
    /// </summary>
    public class ViewController
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="viewDAO">DAO des vues.</param>
        public ViewController(ViewDAO viewDAO)
        {
            ViewDAO = viewDAO;
        }

        /// <summary>
        ///     DAO des vues.
        /// </summary>
        private ViewDAO ViewDAO { get; set; }

        /// <summary>
        ///     Retourne la liste des vues disponibles pour l'utilisateur connecté.
        /// </summary>
        /// <param name="holder">Porte-autorisations.</param>
        /// <returns>Liste des vues disponibles pour l'utilisateur.</returns>
        [Route("/services/views/list")]
        public IList<View> GetViewsForUser([FromServices] AuthenticationHolder holder)
        {
            return ViewDAO.GetViewByUser(holder.Current);
        }
    }
}
