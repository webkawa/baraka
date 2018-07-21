namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Expression.
    ///     Noeud constitutif d'un arbre syntaxique SQL et représentant
    ///     une expression arbitraire (nom de table, de champ, constante...).
    /// </summary>
    internal class StatementToken : ImperativeToken
    {
        /// <summary>
        ///     Nom défini pour l'expression.
        /// </summary>
        internal string Name { get; set; }
    }
}
