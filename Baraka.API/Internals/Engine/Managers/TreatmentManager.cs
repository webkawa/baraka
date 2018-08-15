﻿namespace Baraka.API.Internals.Engine.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Text;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Gestionnaire des traitements.
    ///     Classe chargée de l'ordonnancement des traitements requis par 
    ///     l'application.
    /// </summary>
    internal interface ITreatmentManager : IContractManager<ITreatment>
    {
    }

    /// <summary>
    ///     Gestionnaire des traitements.
    /// </summary>
    internal class TreatmentManager : ContractManager<ITreatment>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        /// <param name="rulers">Liste des décisionnaires.</param>
        public TreatmentManager(Engine engine, IEnumerable<ITreatmentRuler> rulers) : base(engine)
        {
            Rulers = new HashSet<ITreatmentRuler>(rulers);
            Buffer = new Dictionary<ITreatmentGrouper, ITreatmentGroup>();

            OnContractInjected
                .Where((treatment) =>
                {
                    // Filtrage des contrôleurs dont au moins un décisionnaire 
                    // bloque l'exécution
                    if (Rulers.Any((ruler) => ruler.Matches(treatment) && !ruler.Validates(treatment)))
                    {
                        treatment.Finalize(ContractResult.CANCELED);
                        return false;
                    }
                    return true;
                })
                .Subscribe((contract) =>
                {
                    // Re-groupement des traitement injectés
                    var grouper = contract.Grouper;
                    if (Buffer.ContainsKey(grouper))
                    {
                        Buffer[grouper].Add(contract);
                    }
                    else
                    {
                        var group = new TreatmentGroup(this, contract);
                        Buffer.Add(grouper, group);
                    }
                });
        }

        /// <summary>
        ///     Procède à l'exécution immédiate d'un traitement.
        /// </summary>
        /// <param name="treatment">Traitement exécuté.</param>
        internal void Launch(ITreatment treatment)
        {
            // Marquage
            treatment.Run();

            // Attente d'exécution de l'initialisateur
            var init = treatment.Initializer;
            init.OnResultChange.Subscribe((result) =>
            {
                treatment.Finalize(result);
            });

            // Injection
            Engine.ProcessManager.Inject(treatment.Initializer);
        }

        /// <summary>
        ///     Liste des décisionnaires.
        /// </summary>
        private ISet<ITreatmentRuler> Rulers { get; set; }

        /// <summary>
        ///     Tampon.
        ///     Dictionnaire utilisé pour stocker les traitements en attente de
        ///     groupage.
        /// </summary>
        private IDictionary<ITreatmentGrouper, ITreatmentGroup> Buffer { get; set; }
    }
}