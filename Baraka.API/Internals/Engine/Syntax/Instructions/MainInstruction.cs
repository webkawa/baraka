namespace Baraka.API.Internals.Engine.Syntax.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Instruction principale.
    ///     Instruction correspondant à une requête SQL à part entière,
    ///     exploitable par l'utilisateur final.
    /// </summary>
    internal class MainInstruction : AbstractInstruction
    {
        /// <summary>
        ///     Mot-clef ouvrant l'instruction.
        /// </summary>
        internal KeywordToken Keyword
        {
            get
            {
                var result = Root.Children.First() as KeywordToken;
                if (result == null)
                {
                    throw new InternalException("Invalid first node for instruction");
                }

                return result;
            }
        }
    }
}
