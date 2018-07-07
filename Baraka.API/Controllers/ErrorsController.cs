namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Http;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Contrôleurs des erreurs.
    /// </summary>
    public class ErrorsController
    {
        /// <summary>
        ///     Gère une erreur 404.
        /// </summary>
        /// <returns>Résultat de l'action.</returns>
        [Route("error/404")]
        public IActionResult ManageNotFound()
        {
            return new RedirectResult("/index.html", false, true);
        }
    }
}
