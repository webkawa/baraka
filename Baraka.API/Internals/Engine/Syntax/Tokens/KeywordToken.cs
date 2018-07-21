namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Mot-clef.
    ///     Noeud constitutif d'un arbre syntaxique SQL de type mot-clef.
    /// </summary>
    internal class KeywordToken : ImperativeToken
    {
        /// <summary>
        ///     Valeur du mot-clef.
        /// </summary>
        internal string Value { get; set; }
    }
}
