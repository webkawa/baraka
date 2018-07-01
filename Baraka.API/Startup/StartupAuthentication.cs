namespace Baraka.API.Startup
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Authentication;

    /// <summary>
    ///     Démarre le service d'authentification.
    /// </summary>
    internal static class StartupAuthentication
    {
        internal static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            return services
                .AddSingleton((provider) =>
                {
                    return new AuthenticationManager();
                });
        }
    }
}
