namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Baraka.API.Internals.Model;
    using NHibernate;

    /// <summary>
    ///     Dépôt de données.
    /// </summary>
    public abstract class AbstractDAO
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="session">Session.</param>
        public AbstractDAO(ISession session)
        {
            Session = session;
            Dependencies = new Dictionary<Type, object>();

            AddDependency(Session);
            AddDependency(this);
        }
        
        /// <summary>
        ///     Session.
        /// </summary>
        protected ISession Session { get; private set; }

        /// <summary>
        ///     Dépendances du validateur.
        /// </summary>
        private IDictionary<Type, object> Dependencies { get; set; }

        /// <summary>
        ///     Retourne un validateur doté des dépendances précisées au niveau
        ///     de la classe plus dépendances spécifiques.
        /// </summary>
        /// <param name="specifics">Dépendances spécifiques.</param>
        /// <returns>Validateur.</returns>
        public ModelValidator GetValidator(params object[] specifics)
        {
            IDictionary<Type, object> clone = new Dictionary<Type, object>(Dependencies);
            foreach (object spe in specifics)
            {
                clone.Add(spe.GetType(), spe);
            }

            return new ModelValidator(Dependencies);
        }

        /// <summary>
        ///     Ajoute une dépendance aux validateurs générés.
        /// </summary>
        /// <typeparam name="TDependency">Type utilisé comme clef pour accéder à la dépendance.</typeparam>
        /// <param name="value">Valeur affetcée.</param>
        public void AddDependency<TDependency>(TDependency value)
        {
            Dependencies.Add(typeof(TDependency), value);
        }
    }
}
