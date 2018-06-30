namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Views;
    using Baraka.API.Entities;
    using NHibernate;

    /// <summary>
    ///     DAO des vues.
    /// </summary>
    public class ViewDAO : AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        public ViewDAO(ISession session) : base(session)
        {
        }

        /// <summary>
        ///     Insère une vue dans la base de données.
        /// </summary>
        /// <typeparam name="TView">Type de vue.</typeparam>
        /// <param name="label">Libellé.</param>
        /// <param name="model">Modèle.</param>
        /// <returns>Vue créée.</returns>
        public View Insert<TView>(BundleDTO label, TView model)
            where TView : AbstractViewDTO
        {
            View result = new View()
            {
                Label = label,
                Model = model
            };
            Session.Persist(result);
            return result;
        }
    }
}
