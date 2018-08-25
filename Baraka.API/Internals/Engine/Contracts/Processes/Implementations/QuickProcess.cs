namespace Baraka.API.Internals.Engine.Contracts.Processes.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Processus instantané.
    ///     Processus basé sur une action simple passée en paramètre du
    ///     contructeur.
    /// </summary>
    internal class QuickProcess : Process
    {
        /// <summary>
        ///     Constructuer.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        /// <param name="body">Corps du traitement.</param>
        public QuickProcess(IEngine engine, Action<QuickProcess> body) : base(engine)
        {
            Body = body;
        }

        /// <summary>
        ///     Corps du traitement.
        /// </summary>
        private Action<QuickProcess> Body { get; set; }

        /// <summary>
        ///     Exécution.
        /// </summary>
        protected override void Execute()
        {
            Body(this);
        }
    }
}
