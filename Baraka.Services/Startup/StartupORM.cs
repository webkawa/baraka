namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.DTO.Configuration;
    using Baraka.API.Internals.Persistence;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Impl;
    using NHibernate.Mapping.ByCode;

    /// <summary>
    ///     Classe de démarrage de l'ORM.
    /// </summary>
    internal static class StartupORM
    {
        /// <summary>
        ///     Fabrique de sessions.
        /// </summary>
        private static ISessionFactory Factory { get; set; }

        /// <summary>
        ///     Configure et référence l'ORM.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddORM(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped((provider) =>
                {
                    Init(provider.GetService<IOptions<ApplicationConfigurationDTO>>().Value.Database);
                    return Factory.OpenSession();
                })
                .AddScoped((provider) =>
                {
                    Init(provider.GetService<IOptions<ApplicationConfigurationDTO>>().Value.Database);
                    return Factory.OpenStatelessSession();
                })
                .AddScoped((provider) =>
                {
                    return new UserDAO(provider.GetService<ISession>());
                });
        }

        /// <summary>
        ///     Initialise et retourne la fabrique de sessions.
        /// </summary>
        /// <param name="options">Configuration.</param>
        /// <returns>Fabrique de session.</returns>
        private static ISessionFactory Init(DatabaseConfigurationDTO options)
        {
            if (Factory == null)
            {
                // Extraction des types
                var types = Assembly
                    .GetExecutingAssembly()
                    .GetExportedTypes();

                // Création du mappage
                var mapper = new ModelMapper();
                mapper.AddMappings(types);
                var hbm = mapper.CompileMappingForAllExplicitlyAddedEntities();

                // Création de la fabrique
                var pre = new Configuration();
                pre.DataBaseIntegration(db =>
                    {
                        // Informations initiales
                        db.ConnectionString = options.ConnectionString;
                        db.BatchSize = options.BatchSize;
                        db.Dialect<MsSql2012Dialect>();

                    // Gestion du schéma
                    switch (options.Action)
                        {
                            case "Create":
                                db.SchemaAction = SchemaAutoAction.Create;
                                break;

                            case "Recreate":
                                db.SchemaAction = SchemaAutoAction.Recreate;
                                break;

                            case "Update":
                                db.SchemaAction = SchemaAutoAction.Update;
                                break;

                            case "Validate":
                                db.SchemaAction = SchemaAutoAction.Validate;
                                break;

                            default:
                                throw new Error("Invalid database action '{0}'", options.Action);
                        }
                    })
                    .SetNamingStrategy(new BarakaNamingStrategy())
                    .AddMapping(hbm);

                Factory = pre.BuildSessionFactory();
            }

            // Renvoi
            return Factory;
        }
    }
}
