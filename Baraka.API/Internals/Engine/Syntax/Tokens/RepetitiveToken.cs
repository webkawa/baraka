namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Répétition.
    ///     Fragment d'arbre syntaxique SQL représentant une possibilité de répétition
    ///     d'un élément, avec ou sans virgule séparatrice.
    /// </summary>
    internal class RepetitiveToken : ImperativeToken
    {
        /// <summary>
        ///     Virgule de séparation.
        /// </summary>
        internal bool Separator { get; set; }
    }
}
