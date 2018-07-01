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
        ///     Retourne la liste des vues disponibles pour l'utilisateur connecté.
        /// </summary>
        /// <param name="holder">Porte-autorisations.</param>
        /// <param name="viewDAO">DAO des vues.</param>
        /// <returns>Liste des vues disponibles pour l'utilisateur.</returns>
        [Authenticate]
        [Route("/views/get")]
        public IList<View> GetView(
            [FromServices] AuthenticationHolder holder,
            [FromServices] ViewDAO viewDAO)
        {
            return viewDAO.GetViewByUser(holder.Current);
        }
    }
}
