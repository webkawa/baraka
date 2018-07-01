namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    using Baraka.API.Internals.Persistence.Serialization;
    using Baraka.API.Internals.Persistence.Serialization.Converters;
    using Microsoft.AspNetCore.Mvc.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NHibernate;

    /// <summary>
    ///     Classe de démarrage du MVC.
    /// </summary>
    internal static class StartupMVC
    {
        /// <summary>
        ///     Référence les services rattachables à la couche MVC.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <returns>Gestionnaire de configuration.</returns>
        internal static IMvcBuilder AddMvc(this IServiceCollection services)
        {
            var builder = services.AddMvcCore();
            builder.AddFormatterMappings();
            builder.AddJsonFormatters(setup =>
            {
                setup.Converters.Add(new PersistentJsonReferencesConverter());
                setup.Converters.Add(new PersistentJsonCollectionsConverter());
            });
            builder.AddCors();
            return new MvcBuilder(builder.Services, builder.PartManager);
        }
    }
}
