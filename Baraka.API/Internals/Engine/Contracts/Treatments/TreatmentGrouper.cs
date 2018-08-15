namespace Baraka.API.Internals.Engine.Contracts.Treatments
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Classe de groupage non-typée.
    /// </summary>
    internal interface ITreatmentGrouper : ITreatmentAttached
    {
        /// <summary>
        ///     Assemble et planifie un ensemble de traitements groupés.
        /// </summary>
        /// <param name="group">Groupe traité.</param>
        void AssembleAndInject(ISet<ITreatment> group);
    }

    /// <summary>
    ///     Classe de groupage.
    ///     Classe rattachée à un traitement et permettant le groupage sur
    ///     la base d'une comparaison simple entre instances. La classe inclut
    ///     une méthode permettant de réaliser la fusion d'un ensemble de
    ///     traitements partageant le même mode de groupage, et retournant
    ///     un autre traitement (de type défini à l'avance) représentant
    ///     le groupe prêt à injection.
    /// </summary>
    /// <typeparam name="TGroup">Type de traitement groupé.</typeparam>
    internal interface ITreatmentGrouper<TGroup> : ITreatmentGrouper
        where TGroup : ITreatment
    {
        /// <summary>
        ///     Assemble un ensemble de traitements groupés.
        /// </summary>
        /// <param name="group">Groupe traité.</param>
        /// <returns>Traitement de groupe généré.</returns>
        TGroup Assemble(ISet<ITreatment> group);
    }

    /// <summary>
    ///     Classe de groupage.
    /// </summary>
    /// <typeparam name="TGroup">Type de traitement groupé.</typeparam>
    internal abstract class TreatmentGrouper<TGroup> : ITreatmentGrouper<TGroup>
        where TGroup : ITreatment
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="treatment">Traitement porteur.</param>
        public TreatmentGrouper(ITreatment treatment)
        {
            Treatment = treatment;
        }

        /// <summary>
        ///     Traitement porteur.
        /// </summary>
        public ITreatment Treatment { get; private set; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        public ILogger Logger => Treatment.Logger;

        /// <summary>
        ///     <see cref="ITreatmentGrouper.AssembleAndInject(ISet{ITreatment})" />
        /// </summary>
        public void AssembleAndInject(ISet<ITreatment> group)
        {
            // Génération du traitement
            TGroup artifact = Assemble(group);
            Treatment.Pause();

            // Souscription
            artifact.OnFinalized.Subscribe((result) =>
            {
                Treatment.Finalize(result);
            });

            // Injection
            Treatment.Engine.ProcessManager.Inject(artifact.Initializer);
        }

        /// <summary>
        ///     <see cref="ITreatmentGrouper{TGroup}.Assemble(ISet{ITreatment})" />
        /// </summary>
        public abstract TGroup Assemble(ISet<ITreatment> group);
    }
}
