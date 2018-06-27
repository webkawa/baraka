namespace Baraka.API.DAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
        }

        /// <summary>
        ///     Session.
        /// </summary>
        protected ISession Session { get; private set; }
    }
}
