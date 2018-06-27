namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Classe de démarrage du MVC.
    /// </summary>
    internal static class StartupMVC
    {
        /// <summary>
        ///     Référence les services rattachables à la couche MVC.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Gestionnaire de configuration.</returns>
        internal static IMvcBuilder AddMvc(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddMvcCore();
            builder.AddAuthorization();
            builder.AddFormatterMappings();
            builder.AddJsonFormatters();
            builder.AddCors();
            return new MvcBuilder(builder.Services, builder.PartManager);
        }
    }
}
