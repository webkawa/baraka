namespace Baraka.API.Internals.Engine.Syntax.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Sous-instruction.
    ///     Instruction faisant partie intégrante d'une autre.
    /// </summary>
    internal class SubInstruction : AbstractInstruction
    {
        /// <summary>
        ///     Nom de la sous-instruction.
        /// </summary>
        internal string Key { get; set; }
    }
}
