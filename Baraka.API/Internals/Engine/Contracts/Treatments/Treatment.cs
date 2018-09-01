namespace Baraka.API.Internals.Engine.Contracts.Treatments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Processes;
    using Baraka.API.Internals.Engine.Core;
    using Baraka.API.Internals.Engine.Core.Piles;

    /// <summary>
    ///     Interface des traitements.
    /// </summary>
    internal interface ITreatment : IContract, IPlanAttached
    {
        /// <summary>
        ///     Clef de groupage.
        /// </summary>
        IContractGrouper Grouper { get; }

        /// <summary>
        ///     Processus initial.
        /// </summary>
        IProcess Initializer { get; }
    }

    /// <summary>
    ///     Interface des contrats générés par un traitement.
    /// </summary>
    internal interface ITreatmentAttached
    {
        /// <summary>
        ///     Traitement rattaché.
        /// </summary>
        ITreatment Treatment { get; }
    }

    /// <summary>
    ///     Traitement.
    ///     Liste d'opérations, parallèles et/ou séquentielles, représentatives d'un traitement 
    ///     métier unitaire à exécuter au sein de l'application.
    /// </summary>
    internal abstract class Treatment : Contract, ITreatment
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Gestionnaire d'appartenance.</param>
        /// <param name="plan">Plan rattaché.</param>
        /// <param name="initializer">Processus initial.</param>
        public Treatment(IEngine engine, IPlan plan, IProcess initializer) : base(engine)
        {
            Plan = plan;
            Initializer = initializer;
        }

        /// <summary>
        ///     Plan rattaché.
        /// </summary>
        public IPlan Plan { get; private set; }

        /// <summary>
        ///     Processus iniital.
        /// </summary>
        public IProcess Initializer { get; private set; }

        /// <summary>
        ///     Clef de groupage.
        /// </summary>
        public abstract IContractGrouper Grouper { get; }
    }
}
