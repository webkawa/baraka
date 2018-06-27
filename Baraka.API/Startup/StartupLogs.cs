namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using NLog;
    using NLog.Config;
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
        /// <param name="configuration">Configuration.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddLogs(this IServiceCollection services, IConfiguration configuration)
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
                LogManager.Configuration.AddTarget(new FileTarget()
                {
                    Name = "logFile",
                    Layout = options.Format,
                    FileName = string.Format("{0}\baraka.log", options.Folder),
                    ArchiveFileName = string.Format("{0}\baraka.{{####}}.log", options.Folder),
                    ArchiveEvery = FileArchivePeriod.Day,
                    MaxArchiveFiles = options.Until,
                    AutoFlush = true,
                    EnableFileDelete = true,
                    DeleteOldFileOnStartup = true
                });
                LogManager.Configuration.AddRuleForAllLevels("api", "Baraka.API");
                Started = true;
            }
        }
    }
}
