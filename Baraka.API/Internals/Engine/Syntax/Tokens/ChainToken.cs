namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Mode d'utilisation d'un chaîne.
    /// </summary>
    internal enum ChainTokenMode
    {
        /// <summary>
        ///     Concaténation des instructions.
        /// </summary>
        CONCAT,

        /// <summary>
        ///     Sélection d'une instruction.
        /// </summary>
        SELECT
    }

    /// <summary>
    ///     Chaîne.
    ///     Noeud constitutif d'un arbre syntaxique SQL et doté d'une
    ///     liste de sous-noeuds.
    /// </summary>
    internal class ChainToken : AbstractToken
    {
        /// <summary>
        ///     Mode d'utilisation.
        /// </summary>
        internal ChainTokenMode Mode { get; set; }

        /// <summary>
        ///     Liste des sous-noeuds.
        /// </summary>
        internal IList<AbstractToken> Children { get; set; }
    }
}
