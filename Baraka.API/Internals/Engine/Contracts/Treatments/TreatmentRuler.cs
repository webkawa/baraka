namespace Baraka.API.Internals.Engine.Contracts.Treatments
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Décisionnaire non-typé.
    /// </summary>
    internal interface ITreatmentRuler
    {
        /// <summary>
        ///     Indique si le décisionnaire peut prendre en charge un 
        ///     traitement.
        /// </summary>
        /// <param name="treatment">Traitement analysé.</param>
        /// <returns>true si le décisionnaire peut évaluer le traitement.</returns>
        bool Matches(ITreatment treatment);

        /// <summary>
        ///     Indique si le décisionnaire valide l'exécution du traitement
        ///     au sein du plan d'exécution courant.
        /// </summary>
        /// <param name="treatment">Traitement analysé.</param>
        /// <returns>true si le décisionnaire valide l'exécution du traitement.</returns>
        bool Validates(ITreatment treatment);

        /// <summary>
        ///     Prend acte de l'exécution effective du traitement.
        /// </summary>
        /// <param name="treatment">Traitement.</param>
        /// <param name="result">Résultat du traitement.</param>
        void Postback(ITreatment treatment, ContractResult result);
    }

    /// <summary>
    ///     Décisionnaire.
    ///     Classe dédiée à la prise de décision concernant le lancement
    ///     d'un traitement dans un contexte (plan) donné. Les décisionnaires
    ///     sont stockés à la suite les uns des autres et ré-évalués à
    ///     chaque injection d'un traitement. Si aucun décisionnaire ne
    ///     peut prendre en charge le traitement, celui-ci génère sa propre
    ///     instance.
    ///     La configuration du décisionnaire est définie par le biais d'un
    ///     attribut dédié dont la présence valide son utilisation sur le contrat
    ///     concerné.
    /// </summary>
    /// <typeparam name="TConfiguration">Type d'attribut utilisé pour la configuration.</typeparam>
    internal interface ITreatmentRuler<TConfiguration> : ITreatmentRuler
        where TConfiguration : Ruled
    {
        /// <summary>
        ///     Indique si une configuration adaptée au décisionnaire peut être extraite d'un
        ///     traitement.
        /// </summary>
        /// <param name="treatment">Traitement évalué.</param>
        /// <returns>true si la configuration peut être extraite, false sinon.</returns>
        bool HasConfiguration(ITreatment treatment);

        /// <summary>
        ///     Retourne la configuration rattachée à un traitement pour le décisionnaire
        ///     courant.
        /// </summary>
        /// <param name="treatment">Traitement évalué.</param>
        /// <returns>Configuration.</returns>
        TConfiguration GetConfiguration(ITreatment treatment);
    }

    /// <summary>
    ///     Implémentation du décisionnaire.
    /// </summary>
    /// <typeparam name="TConfiguration">Type d'attribut utilisé.</typeparam>
    internal abstract class TreatmentRuler<TConfiguration> : ITreatmentRuler<TConfiguration>
        where TConfiguration : Ruled
    {
        /// <summary>
        ///     <see cref="ITreatmentRuler{TAttribute}.HasConfiguration(ITreatment)" />
        /// </summary>
        public bool HasConfiguration(ITreatment treatment)
        {
            return GetConfiguration(treatment) != null;
        }

        /// <summary>
        ///     Retourne la configuration rattachée à un traitement pour le décisionnaire
        ///     courant.
        /// </summary>
        /// <param name="treatment">Traitement évalué.</param>
        /// <returns>Configuration.</returns>
        public TConfiguration GetConfiguration(ITreatment treatment)
        {
            return treatment
                .GetType()
                .GetCustomAttribute<TConfiguration>();
        }

        /// <summary>
        ///     <see cref="ITreatmentRuler.Matches(ITreatment)" />
        /// </summary>
        public bool Matches(ITreatment treatment)
        {
            return HasConfiguration(treatment);
        }

        /// <summary>
        ///     <see cref="ITreatmentRuler.Validates(ITreatment)" />
        /// </summary>
        public bool Validates(ITreatment treatment)
        {
            return Validates(treatment, GetConfiguration(treatment));
        }

        /// <summary>
        ///     Méthode interne de validation.
        /// </summary>
        /// <param name="treatment">Traitement évalué.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>true si le décisionnaire valide le traitement, false sinon.</returns>
        public abstract bool Validates(ITreatment treatment, TConfiguration configuration);

        /// <summary>
        ///     <see cref="ITreatmentRuler.Postback(ITreatment, ContractResult)" />
        /// </summary>
        public void Postback(ITreatment treatment, ContractResult result)
        {
            Postback(treatment, result, GetConfiguration(treatment));
        }

        /// <summary>
        ///     Méthode interne d'enregistrement.
        /// </summary>
        /// <param name="treatment">Traitement évalué.</param>
        /// <param name="result">Résultat du traitement.</param>
        /// <param name="configuration">Configuration.</param>
        public abstract void Postback(ITreatment treatment, ContractResult result, TConfiguration configuration);
    }

    /// <summary>
    ///     Attribut permettant le paramétrage d'un type de contrat géré par 
    ///     un décisionnaire.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal abstract class Ruled : Attribute
    {
    }
}
