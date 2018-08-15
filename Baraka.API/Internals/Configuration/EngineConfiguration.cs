namespace Baraka.API.Internals.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Configuration du moteur.
    /// </summary>
    public class EngineConfiguration
    {
        /// <summary>
        ///     Seuil d'injection des traitements.
        ///     Délai en millisecondes représentatif du temps d'attente, suite
        ///     au référencement d'un traitement unitaire dans un groupe plus
        ///     large, avant groupage et injection.
        /// </summary>
        public long TreatmentsTick { get; set; }
    }
}
