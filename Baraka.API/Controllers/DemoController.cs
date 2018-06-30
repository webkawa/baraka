namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Configurations;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Views;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes;
    using Microsoft.AspNetCore.Mvc;
    using NHibernate;
    using NLog;

    /// <summary>
    ///     Services liées à l'initialisation de l'application.
    /// </summary>
    public class DemoController
    {
        /// <summary>
        ///     Génération des données de démonstration.
        /// </summary>
        /// <param name="userDAO">DAO des utilisateurs.</param>
        /// <param name="tableDAO">DAO des tables.</param>
        /// <param name="fieldDAO">DAO des champs.</param>
        /// <param name="viewDAO">DAO des vues.</param>
        [Route("/")]
        [Transactional]
        public string Demo(
            [FromServices] UserDAO userDAO,
            [FromServices] TableDAO tableDAO,
            [FromServices] FieldDAO fieldDAO,
            [FromServices] ViewDAO viewDAO)
        {
            User user = userDAO.Insert("kawa", "kawa", "guillaume.zavan@gmail.com", new UserConfigurationDTO()
            {
                Culture = Langage.FRA
            });
            
            Table table = tableDAO.Insert(
                new BundleDTO()
                {
                    Data = new Dictionary<Langage, string>()
                    {
                        {
                            Langage.FRA, "Contact"
                        }
                    }
                },
                "contacts");

            Field field_lastname = fieldDAO.Insert(
                new BundleDTO()
                {
                    Data = new Dictionary<Langage, string>()
                    {
                        {
                            Langage.FRA, "Nom"
                        }
                    }
                },
                "lastname",
                table);

            Field field_firstname = fieldDAO.Insert(
                new BundleDTO()
                {
                    Data = new Dictionary<Langage, string>()
                    {
                        {
                            Langage.FRA, "Prénom"
                        }
                    }
                },
                "firstname",
                table);

            View view = viewDAO.Insert(
                new BundleDTO()
                {
                    Data = new Dictionary<Langage, string>()
                    {
                        {
                            Langage.FRA, "Mode liste"
                        }
                    }
                },
                new ListViewDTO()
                {
                    Table = table
                });

            return "ok";
        }
    }
}
