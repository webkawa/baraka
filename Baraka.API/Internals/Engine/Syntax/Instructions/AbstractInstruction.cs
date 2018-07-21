namespace Baraka.API.Internals.Engine.Syntax.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Instruction.
    ///     Racine d'un arbre syntaxique SQL représentatif d'une requête
    ///     ou fragment de requête.
    /// </summary>
    internal abstract class AbstractInstruction
    {
        /// <summary>
        ///     Chaîne constituant l'instruction.
        /// </summary>
        internal ChainToken Root { get; set; }
    }
}
