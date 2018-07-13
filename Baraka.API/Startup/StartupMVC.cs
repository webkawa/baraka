namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization.Formatters;
    using System.Security.Claims;
    using System.Text;

    using Baraka.API.Internals.Attributes.Mvc;
    using Baraka.API.Internals.Persistence.Serialization;
    using Baraka.API.Internals.Persistence.Serialization.Converters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Internal;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var builder = services.AddMvcCore((setup) =>
            {

                setup.Filters.Add(new ManageException());
                setup.Filters.Add(new Authenticate());
            });
            builder.AddFormatterMappings();
            builder.AddJsonFormatters(setup =>
            {
                setup.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                /*setup.TypeNameHandling = TypeNameHandling.Auto;
                setup.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
                setup.SerializationBinder = new PersistedJsonTypeBinderr();*/

                setup.Converters.Add(new GenericPersistedJsonConverter());
                setup.Converters.Add(new PersistedJsonReferencesConverter());
                setup.Converters.Add(new PersistedJsonCollectionsConverter());
            });
            builder.AddCors();
            return new MvcBuilder(builder.Services, builder.PartManager);
        }
    }
}
