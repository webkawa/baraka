namespace Baraka.API.Startup
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Configuration;
    using Baraka.API.Internals.Persistence;
    using Baraka.API.Internals.Persistence.Syntax;
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
        ///     Configure et référence l'ORM.
        /// </summary>
        /// <param name="services">Liste des services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Liste des services.</returns>
        internal static IServiceCollection AddORM(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton((provider) =>
                {
                    // Récupération des options
                    DatabaseConfiguration options = provider
                        .GetService<IOptions<ApplicationConfiguration>>()
                        .Value
                        .Database;

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
                    pre.DataBaseIntegration(
                        db =>
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
                                    throw new InternalException("Invalid database action '{0}'", options.Action);
                            }
                        })
                        .SetNamingStrategy(new NamingStrategy())
                        .AddMapping(hbm);
                    
                    return pre.BuildSessionFactory();
                })
                .AddScoped((provider) =>
                {
                    return provider.GetService<ISessionFactory>().OpenSession();
                })
                .AddScoped((provider) =>
                {
                    return provider.GetService<ISessionFactory>().OpenStatelessSession();
                })
                .AddScoped<IDbConnection>((provider) =>
                {
                    return provider.GetService<IStatelessSession>().Connection;
                })
                .AddScoped((provider) => new FieldDAO(provider.GetService<ISession>()))
                .AddScoped((provider) => new TableDAO(provider.GetService<ISession>()))
                .AddScoped((provider) => new UserDAO(provider.GetService<ISession>()))
                .AddScoped((provider) => new ViewDAO(provider.GetService<ISession>()));
        }
    }
}
