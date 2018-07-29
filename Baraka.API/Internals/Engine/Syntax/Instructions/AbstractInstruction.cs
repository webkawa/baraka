namespace Baraka.API.Internals.Engine.Syntax.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Interface des instructions.
    /// </summary>
    internal interface IInstruction
    {
    }

    /// <summary>
    ///     Instruction.
    ///     Racine d'un arbre syntaxique SQL représentatif d'une requête
    ///     ou fragment de requête.
    /// </summary>
    /// <typeparam name="TRoot">Type du noeud racine.</typeparam>
    internal abstract class AbstractInstruction<TRoot> : IInstruction
        where TRoot : AbstractToken
    {
        /// <summary>
        ///     Noeud racine.
        /// </summary>
        internal TRoot Root { get; set; }
    }
}
