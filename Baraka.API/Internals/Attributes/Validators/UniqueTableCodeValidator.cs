namespace Baraka.API.Internals.Attributes.Validators
{
    using Baraka.API.DAO;
    using NHibernate;
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
            ISession session = GetContextParameter<ISession>(context);
            TableDAO dao = new TableDAO(session);
            string typed = value as string;
            return dao.IsTableCodeAvailable(typed) ? 
                ValidationResult.Success : 
                new ValidationResult("Table code is unavailable");
        }
    }
}
