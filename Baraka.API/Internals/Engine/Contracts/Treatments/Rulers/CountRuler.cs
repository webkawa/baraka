namespace Baraka.API.Internals.Engine.Contracts.Treatments.Rulers
{
    using Baraka.API.Internals.Engine.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Décisionnaire par décompte.
    ///     Décisionnaire basé sur un nombre maximum d'exécutions par type ou
    ///     interface de traitement.
    /// </summary>
    internal class CountRuler : TreatmentRuler<RuledByCount>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public CountRuler()
        {
            Counts = new Dictionary<IContractGrouper, int>();
        }

        /// <summary>
        ///     Etat des décomptes.
        /// </summary>
        private IDictionary<IContractGrouper, int> Counts { get; set; }

        /// <summary>
        ///     Valide le traitement sous réserve que le décompte soit inférieur au 
        ///     maximum toléré.
        /// </summary>
        /// <param name="treatment">Traitement testé.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>true si le décisionnaire valide le traitement, false sinon.</returns>
        public override bool Validates(ITreatment treatment, RuledByCount configuration)
        {
            return Counts.ContainsKey(treatment.Grouper) && Counts[treatment.Grouper] < configuration.Maximum;
        }

        /// <summary>
        ///     Procède à la mise à jour du dictionnaire.
        /// </summary>
        /// <param name="treatment">Traitement testé.</param>
        /// <param name="result">Résultat du traitement.</param>
        /// <param name="configuration">Configuration.</param>
        public override void Postback(ITreatment treatment, ContractResult result, RuledByCount configuration)
        {
            if (Counts.ContainsKey(treatment.Grouper))
            {
                Counts[treatment.Grouper]++;
            }
            else
            {
                Counts.Add(treatment.Grouper, 1);
            }
        }
    }

    /// <summary>
    ///     Attribut applicable aux contrats gérés par un décisionnaire
    ///     sur décompte.
    /// </summary>
    internal class RuledByCount : Ruled
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="max">Nombre maximum d'itérations.</param>
        public RuledByCount(int max = 3)
        {
            Maximum = max;
            IgnoreFails = false;
        }

        /// <summary>
        ///     Nombre maximum d'itérations.
        /// </summary>
        public virtual int Maximum { get; set; }

        /// <summary>
        ///     Indique si les échecs doivent être pris en compte dans le décompte.
        /// </summary>
        public virtual bool IgnoreFails { get; set; }
    }
}
