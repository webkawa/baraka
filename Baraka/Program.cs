namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Corps de l'application.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Méthode principales.
        /// </summary>
        /// <param name="args">Arguments de démarrage.</param>
        public static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hc, configuration) =>
                {

                    var env = hc.HostingEnvironment;
                    configuration
                        .AddJsonFile("baraka.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"baraka.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((hc, logging) =>
                {
                    logging
                        .AddFilter((level) =>
                        {
                            return level > LogLevel.Trace;
                        });
                })
                .UseStartup<Startup>()
                .Build()
                .Run();
        }   
    }
}
