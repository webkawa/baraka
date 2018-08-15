namespace Baraka.API.Internals.Engine.Contracts.Treatments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Text;

    using Baraka.API.Internals.Engine.Managers;

    /// <summary>
    ///     Groupe de traitements.
    ///     Liste de traitements partageant une classe de groupage
    ///     commune et pouvant, à ce titre, être exécutés sous la forme
    ///     d'un traitement unique. La liste peut être complétée par le
    ///     biais d'une méthode dédiée et inclut un mécanisme procédant
    ///     au groupement et à la planification des tâches qu'il accueille
    ///     passé une durée d'inactivité donnée.
    /// </summary>
    internal interface ITreatmentGroup
    {
        /// <summary>
        ///     Gestionnaire d'appartenance.
        /// </summary>
        TreatmentManager Manager { get; }

        /// <summary>
        ///     Classe de groupage.
        /// </summary>
        ITreatmentGrouper Grouper { get; }

        /// <summary>
        ///     Référence un traitement unitaire dans le groupe.
        /// </summary>
        /// <param name="treatment">Traitement référencé.</param>
        void Add(ITreatment treatment);
    }

    internal class TreatmentGroup : ITreatmentGroup
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="manager">Gestionnaire de rattachement.</param>
        /// <param name="initial">Traitment initial.</param>
        public TreatmentGroup(TreatmentManager manager, ITreatment initial)
        {
            Manager = manager;
            Grouper = initial.Grouper;
            Components = new HashSet<ITreatment>();

            Add(initial);
        }

        /// <summary>
        ///     Gestionnaire d'appartenance.
        /// </summary>
        public TreatmentManager Manager { get; private set; }

        /// <summary>
        ///     Classe de groupage.
        /// </summary>
        public ITreatmentGrouper Grouper { get; private set; }

        /// <summary>
        ///     Observable émettant un (et un seul) élément quand le groupe
        ///     doit être émis.
        /// </summary>
        private IObservable<long> Timer => Observable.Timer(TimeSpan.FromMilliseconds(Manager.Engine.Configuration.TreatmentsTick));
        
        /// <summary>
        ///     Observateur en attente.
        /// </summary>
        private IDisposable Waiter { get; set; }

        /// <summary>
        ///     Liste des traitements référencés dans le groupe.
        /// </summary>
        private ISet<ITreatment> Components { get; set; }

        /// <summary>
        ///     <see cref="ITreatmentGroup.Add(ITreatment)" />
        /// </summary>
        public void Add(ITreatment treatement)
        {
            Components.Add(treatement);
            Watch();
        }

        /// <summary>
        ///     Ré-initialise le processus d'attente.
        /// </summary>
        private void Watch()
        {
            Waiter?.Dispose();
            Waiter = Timer.Subscribe((time) =>
            {
                if (Components.Count == 1)
                {
                    Manager.Launch(Components.Single());
                }
                else if (Components.Count > 1)
                {
                    Grouper.AssembleAndInject(Components);
                }

                Components.Clear();
            });
        }


    }
}
