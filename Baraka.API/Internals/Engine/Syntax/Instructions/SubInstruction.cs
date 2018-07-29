namespace Baraka.API.Internals.Engine.Syntax.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Sous-instruction.
    ///     Instruction faisant partie intégrante d'une autre.
    /// </summary>
    internal class SubInstruction : AbstractInstruction<AbstractToken>
    {
        /// <summary>
        ///     Nom de la sous-instruction.
        /// </summary>
        internal string Key { get; set; }
    }
}
