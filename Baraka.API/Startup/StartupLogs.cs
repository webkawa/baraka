namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Configuration;
    using Baraka.API.Internals.Logging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using NLog;
    using NLog.Config;
    using NLog.LayoutRenderers;
    using NLog.Targets;

    /// <summary>
    ///     Classe de démarrage des logs.
    /// </summary>
    internal static class StartupLogs
    {
        /// <summary>
        ///     Marqueur de démarrage.
        /// </summary>
        private static bool Started { get; set; }

        /// <summary>
        ///     Configure et référence les logs.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddLogs(this IServiceCollection services)
        {
            return services
                .AddScoped<ILogger>((provider) =>
                {
                    Init(provider.GetService<IOptions<ApplicationConfiguration>>().Value.Logging);
                    return LogManager.GetLogger("baraka");
                });
        }

        /// <summary>
        ///     Initialisation de la configuration.
        /// </summary>
        /// <param name="options">Liste des options.</param>
        private static void Init(LoggerConfiguration options)
        {
            if (!Started)
            {
                LayoutRenderer.Register<CustomLayoutRenderer>("baraka");

                var configuration = new LoggingConfiguration();
                var file = new FileTarget("api")
                {
                    Layout = "${baraka}",
                    FileName = string.Format("{0}\\baraka.log", options.Folder),
                    ArchiveFileName = string.Format("{0}\\baraka.{{####}}.log", options.Folder),
                    ArchiveEvery = FileArchivePeriod.Day,
                    MaxArchiveFiles = options.Until,
                    AutoFlush = true,
                    EnableFileDelete = true,
                    DeleteOldFileOnStartup = true
                };
                configuration.AddTarget(file);
                configuration.AddRuleForAllLevels(file);

                LogManager.Configuration = configuration;
                LogManager.ReconfigExistingLoggers();

                Started = true;
            }
        }
    }
}
