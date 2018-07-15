namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.DTO.Persisted.Fields;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.Entities;
    using Baraka.API.Internals.Model;
    using NHibernate;

    /// <summary>
    ///     DAO des champs.
    /// </summary>
    public class FieldDAO : AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session empruntée.</param>
        public FieldDAO(ISession session) : base(session)
        {
        }

        /// <summary>
        ///     Insère un champ dans la base.
        /// </summary>
        /// <param name="field">Champ à insérer.</param>
        /// <returns>Champ inséré.</returns>
        public Field Insert(Field field)
        {
            GetValidator().Check(field);
            Session.Persist(field);
            return field;
        }

        /// <summary>
        ///     Réalise la mise à jour d'un champ à partir d'un objet détaché.
        /// </summary>
        /// <param name="field">Objet détaché.</param>
        /// <returns>Objet mis à jour.</returns>
        public Field Update(Field field)
        {
            GetValidator().Check(field);
            return Session.Merge(field);
        }
    }
}
