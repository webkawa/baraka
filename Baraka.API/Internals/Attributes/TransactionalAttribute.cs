namespace Baraka.API.Internals.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Filters;
    using NHibernate;

    /// <summary>
    ///     Annotation englobant une méthode exploitant une transaction SQL unique.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Transactional : ActionFilterAttribute
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="level">Niveau d'isolation de la transaction.</param>
        public Transactional(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            Level = level;
        }

        /// <summary>
        ///     Session d'appui.
        /// </summary>
        private ISession Session { get; set; }

        /// <summary>
        ///     Transaction.
        /// </summary>
        private ITransaction Transaction { get; set; }

        /// <summary>
        ///     Niveau d'isolation.
        /// </summary>
        private IsolationLevel Level { get; set; }

        /// <summary>
        ///     Méthode d'ouverture de la transaction.
        /// </summary>
        /// <param name="context">Contexte d'exécution.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Récupération de la session
            Session = context
                .HttpContext
                .RequestServices
                .GetService(typeof(ISession)) as ISession;

            // Ouverture de la transaction
            Transaction = Session.BeginTransaction(Level);
        }

        /// <summary>
        ///     Méthode de clôture de la transaction.
        /// </summary>
        /// <param name="context">Contexte d'exécution.</param>
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Exception == null)
            {
                Transaction.Commit();
            }
            else
            {
                Transaction.Rollback();
            }
        }
    }
}
