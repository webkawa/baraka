﻿namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Classe de démarrage de la configuration.
    /// </summary>
    internal static class StartupOptions
    {
        /// <summary>
        ///     Référence la configuration.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <param name="source">Configuration source.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration source)
        {
            return services
                .AddOptions()
                .Configure<ApplicationConfiguration>(source);
        }
    }
}
