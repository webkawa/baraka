namespace Baraka.API.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Baraka.API.Internals.Configuration;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    ///     Erreur de saisie.
    ///     Erreur levée suite à un échec de validation du modèle dû à une saisie utilisateur invalide.
    /// </summary>
    internal class InputException : ApiException
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="results">Résultat de la validation.</param>
        /// <param name="message">Message d'erreur.</param>
        /// <param name="format">Arguments de formatage.</param>
        public InputException(IList<ValidationResult> results, string message, params object[] format) : base(message, format)
        {
            Display = BundleId.ERROR_UNKNOW_INPUT;
            Results = results;
        }

        /// <summary>
        ///     Résultats de la validation.
        /// </summary>
        public IList<ValidationResult> Results { get; private set; }
    }
}
