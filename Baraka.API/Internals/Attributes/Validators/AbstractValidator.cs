namespace Baraka.API.Internals.Attributes.Validators
{
    using Baraka.API.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    ///     Validateur.
    ///     Validateur personnalisé respectant la composante <see cref="System.ComponentModel.DataAnnotations" />.
    /// </summary>
    public abstract class AbstractValidator : ValidationAttribute
    {
        /// <summary>
        ///     Retourne un paramètre de contexte par le biais de son type.
        /// </summary>
        /// <typeparam name="TParameter">Type du paramètre recherché.</typeparam>
        /// <param name="validationContext">Contexte de validation.</param>
        /// <returns>Paramètre.</returns>
        protected TParameter GetContextParameter<TParameter>(ValidationContext validationContext)
        {
            if (validationContext.Items.ContainsKey(typeof(TParameter)))
            {
                return (TParameter)validationContext.Items[typeof(TParameter)];
            }

            throw new InternalException("Validator tried to access a missing parameter of type '{0}'", typeof(TParameter));
        }
    }
}
