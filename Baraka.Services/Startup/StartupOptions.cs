namespace Baraka.API.Startup
{
    using Baraka.API.DTO.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Classe de démarrage de la configuration.
    /// </summary>
    internal static class StartupOptions
    {
        /// <summary>
        ///     Référence la configuration.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration source)
        {
            return services
                .AddOptions()
                .Configure<ApplicationConfigurationDTO>(source);
        }
    }
}
