namespace Baraka.API.Internals.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    using Baraka.API.Exceptions;

    /// <summary>
    ///     Validateur de modèle.
    ///     Classe utilitaire permettant la validation d'un ou plusieurs objets sur
    ///     la base des attributs qu'ils portent.
    /// </summary>
    public class ModelValidator
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="arguments">Liste des arguments passés au validateur.</param>
        public ModelValidator(params object[] arguments)
        {
            Parameters = new Dictionary<object, object>();
            foreach (object arg in arguments)
            {
                if (Parameters.ContainsKey(arg.GetType()))
                {
                    throw new InternalException("Duplicate of type '{0}' found in model validator", arg.GetType());
                }
                else
                {
                    Parameters.Add(arg.GetType(), arg);
                }
            }
        }

        /// <summary>
        ///     Paramètres.
        /// </summary>
        private IDictionary<object, object> Parameters { get; set; }

        /// <summary>
        ///     Procède à la validation d'un objet passé en paramètre.
        /// </summary>
        /// <param name="value">Objet validé.</param>
        /// <returns>Liste des erreurs.</returns>
        public IList<ValidationResult> Validate(object value)
        {
            IList<ValidationResult> results = new List<ValidationResult>();
            ValidationContext vc = new ValidationContext(value, Parameters);
            Validator.TryValidateObject(value, vc, results, true);
            return results;
        }

        /// <summary>
        ///     Procède à la validation d'un objet passé en paramètre et projète une erreur
        ///     si nécessaire.
        /// </summary>
        /// <param name="value">Valeur évaluée.</param>
        public void Check(object value)
        {
            var errors = Validate(value);
            if (errors.Any())
            {
                throw new InputException(
                    errors,
                    "Model validation failed on controller execution : [{0}]...",
                    string.Join('|', errors.Select(e => e.ErrorMessage).ToArray()));
            }
        }
    }
}
