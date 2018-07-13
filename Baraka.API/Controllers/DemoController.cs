namespace Baraka.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    using Baraka.API.DAO;
    using Baraka.API.DTO.Persisted;
    using Baraka.API.DTO.Persisted.Users;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Views;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Attributes.Mvc;
    using Baraka.API.Internals.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using NHibernate;
    using NLog;
    using Baraka.API.DTO.Persisted.Tables;
    using Baraka.API.DTO.Persisted.Fields;

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
                User user = userDAO.Insert(new User()
                {
                    Login = "kawa",
                    Password = "kawa",
                    Email = "guillaume.zavan@gmail.com",
                    Configuration = new UserConfigurationDTO()
                });

                Table table = tableDAO.Insert(new Table()
                {
                    Label = new BundleDTO(Langage.FRA, "Contact"),
                    Code = "contacts",
                    Configuration = new TableConfigurationDTO()
                    {
                        Archived = false
                    }
                });

                Field field_lastname = fieldDAO.Insert(new Field()
                {
                    Label = new BundleDTO(Langage.FRA, "Nom"),
                    Code = "lastname",
                    Configuration = new StringFieldConfigurationDTO()
                    {
                    },
                    Table = table
                });

                Field field_firstname = fieldDAO.Insert(new Field()
                {
                    Label = new BundleDTO(Langage.FRA, "Prénom"),
                    Code = "firstname",
                    Configuration = new StringFieldConfigurationDTO()
                    {
                    },
                    Table = table
                });

                View admin_view = viewDAO.Insert(new View()
                {
                    Label = new BundleDTO(Langage.FRA, "Administration"),
                    Configuration = new AdminViewConfigurationDTO()
                    {

                    }
                });

                View list_view = viewDAO.Insert(new View()
                {
                    Label = new BundleDTO(Langage.FRA, "Mode liste"),
                    Configuration = new ListViewConfigurationDTO()
                    {
                        Table = table
                    }
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
