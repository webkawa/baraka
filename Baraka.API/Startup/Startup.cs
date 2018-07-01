namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Baraka.API.Internals.Configuration;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    /// <summary>
    ///     Classe de démarrage.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="configuration">Service de configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     Configuration.
        /// </summary>
        private IConfiguration Configuration { get; set; }

        /// <summary>
        ///     Configuration des services.
        /// </summary>
        /// <param name="services">Classe d'instanciation.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions(Configuration);
            services.AddMvc();
            services.AddORM(Configuration);
            services.AddAuthentication();
        }
        
        /// <summary>
        ///     Configure le traitement des requêtes HTTP.
        /// </summary>
        /// <param name="app">Constructeur applicatif.</param>
        /// <param name="env">Environnement.</param>
        /// <param name="configuration">Configuration.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<ApplicationConfiguration> configuration)
        {
            // Mode développeur
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Configuration
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
