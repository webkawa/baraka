namespace Baraka.API.Internals.Attributes.Mvc
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Http;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Configuration;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;

    /// <summary>
    ///     Filtre de gestion des exceptions.
    /// </summary>
    public class ManageException : ExceptionFilterAttribute
    {
        /// <summary>
        ///     <see cref="ExceptionFilterAttribute.OnException(ExceptionContext)" />
        /// </summary>
        public override void OnException(ExceptionContext context)
        {
            /* Récupération de la configuration */
            ApplicationConfiguration configuration = (context
                .HttpContext
                .RequestServices
                .GetService(typeof(IOptions<ApplicationConfiguration>)) as IOptions<ApplicationConfiguration>)
                .Value;

            /* Récupération du gestionnaire de logs */
            ILogger<ManageException> logger = (context
                .HttpContext
                .RequestServices
                .GetService(typeof(ILoggerFactory)) as ILoggerFactory)
                .CreateLogger<ManageException>();

            /* Affectation du code de réponse */
            context.HttpContext.Response.StatusCode = context.Exception is AuthenticationException ? 403 : 500;

            /* Ecriture dans les logs */
            logger.LogError(context.Exception, "The following error has been catched by the MVC error handler");

            /* Récupération  du lot approprié */
            BundleId id = (context.Exception as ApiException)?.Display ?? BundleId.ERROR_UNKNOW;
            BundleDTO bundle = configuration.Bundles[id];

            /* Ecriture de la réponse */
            context.Result = new JsonResult(new ErrorDTO()
            {
                Code = context.HttpContext.Response.StatusCode,
                Message = bundle
            });
            base.OnException(context);
        }
    }
}
