namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Référence.
    ///     Noeud d'arbre syntaxique SQL faisant référence à une sous-instruction
    ///     tierce.
    /// </summary>
    internal class ReferenceToken : ImperativeToken
    {
        /// <summary>
        ///     Clef d'accès à la sous-instruction.
        /// </summary>
        internal string Key { get; set; }
    }
}
