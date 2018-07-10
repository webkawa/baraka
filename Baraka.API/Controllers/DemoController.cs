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
    using Baraka.API.Internals.Attributes.Mvc;
    using Baraka.API.Internals.Authentication;
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
        /// <param name="session">Session.</param>
        /// <param name="manager">Gestionnaire d'authentification.</param>
        /// <param name="userDAO">DAO des utilisateurs.</param>
        /// <param name="tableDAO">DAO des tables.</param>
        /// <param name="fieldDAO">DAO des champs.</param>
        /// <param name="viewDAO">DAO des vues.</param>
        [Public]
        [Transactional]
        [Route("/services/demo")]
        public void Demo(
            [FromServices] ISession session,
            [FromServices] AuthenticationManager manager,
            [FromServices] UserDAO userDAO,
            [FromServices] TableDAO tableDAO,
            [FromServices] FieldDAO fieldDAO,
            [FromServices] ViewDAO viewDAO)
        {
            if (session.QueryOver<User>().RowCount() == 0)
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

                View admin_view = viewDAO.Insert(
                    new BundleDTO()
                    {
                        Data = new Dictionary<Langage, string>()
                        {
                        {
                            Langage.FRA, "Administration"
                        }
                        }
                    },
                    new AdminViewDTO()
                    {

                    });

                View list_view = viewDAO.Insert(
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
            };
        }

        [Route("/services/post")]
        [Transactional]
        public IList<View> Post(
            [FromServices] ISession session,
            [FromServices] UserDAO userDAO,
            [FromServices] TableDAO tableDAO,
            [FromServices] FieldDAO fieldDAO,
            [FromServices] ViewDAO viewDAO)
        {
            return session.QueryOver<View>().List();
        }
    }
}
