namespace Baraka.API.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;

    /// <summary>
    ///     Extensions applicables aux expressions lambda.
    /// </summary>
    internal static class LambdaExtensions
    {
        /// <summary>
        ///     Retourne le nom littéral d'une propriété passée en paramètres.
        /// </summary>
        /// <typeparam name="TOwner">Type d'objet porteur.</typeparam>
        /// <param name="property">Propriété annalisée</param>
        /// <returns></returns>
        internal static string GetPropertyName<TOwner>(Expression<Func<TOwner, object>> property)
        {
            return (property.Body as MemberExpression).Member.Name;
        }
    }
}
