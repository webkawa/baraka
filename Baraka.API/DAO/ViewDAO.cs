namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Views;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Model;
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
        /// <param name="view">Vue à créer.</param>
        /// <returns>Vue créée.</returns>
        public View Insert(View view)
        {
            GetValidator().Check(view);
            Session.Persist(view);
            return view;
        }

        /// <summary>
        ///     Retourne la liste des vues disponibles à un utilisateur.
        /// </summary>
        /// <param name="user">Utilisateur ciblé.</param>
        /// <returns>Liste des vues.</returns>
        public IList<View> GetViewByUser(User user)
        {
            // TODO : filtrer
            return Session
                .QueryOver<View>()
                .List();
        }
    }
}
