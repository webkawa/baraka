namespace Baraka.API.Internals.Engine.Contracts.Processes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Processus.
    ///     Tâche unitaire mobilisant de manière intensive ou durable les
    ///     ressources propres de l'application (calculs, écritures de 
    ///     fichiers, etc.).
    /// </summary>
    internal interface IProcess : IContract, IPlanAttached
    {
    }

    /// <summary>
    ///     Processus.
    /// </summary>
    internal abstract class Process : Contract, ITreatmentAttached
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        /// <param name="treatment">Traitement d'origine.</param>
        public Process(Engine engine, Treatment treatment) : base(engine)
        {
            Treatment = treatment;
        }

        /// <summary>
        ///     Traitement d'origine.
        /// </summary>
        public ITreatment Treatment { get; private set; }

        /// <summary>
        ///     Plan d'origine.
        /// </summary>
        public IPlan Plan => Treatment.Plan;

        /// <summary>
        ///     Exécution.
        ///     Corps du processus.
        /// </summary>
        protected abstract void Execute();
    }
}
