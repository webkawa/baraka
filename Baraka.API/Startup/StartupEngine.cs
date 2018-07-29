namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Baraka.API.Internals.Engine.Syntax.Factory;
    using Baraka.API.Internals.Engine.Syntax.Specification;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Classe de démarrage du moteur.
    /// </summary>
    internal static class StartupEngine
    {
        /// <summary>
        ///     Référence les services rattachables au moteur de requêtage.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddEngine(this IServiceCollection services)
        {
            return services
                .AddSingleton((provider) =>
                {
                    var result = new SyntaxValidator();
                    result.Load(TSQLSpecification.INSERT);
                    return result;
                });
        }
    }
}
