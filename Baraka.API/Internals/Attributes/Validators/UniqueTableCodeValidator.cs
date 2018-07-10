namespace Baraka.API.Internals.Attributes.Validators
{
    using Baraka.API.DAO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    ///     Vérifie l'unicité du code affecté à une table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueTableCode : AbstractValidator
    {
        /// <summary>
        ///     <see cref="ValidationAttribute.IsValid(object, ValidationContext)" />
        /// </summary>
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            TableDAO dao = GetContextParameter<TableDAO>(context);
            string typed = value as string;
            return dao.IsCodeAvailable(typed) ? 
                ValidationResult.Success : 
                new ValidationResult("Table code is unavailable");
        }
    }
}
