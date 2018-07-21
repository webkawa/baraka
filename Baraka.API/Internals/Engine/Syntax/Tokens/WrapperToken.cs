namespace Baraka.API.Internals.Engine.Syntax.Tokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Type d'enveloppe.
    /// </summary>
    internal enum WrapperTokenType
    {
        /// <summary>
        ///     Sous-composant obligatoire.
        /// </summary>
        MANDATORY,

        /// <summary>
        ///     Sous-composant facultatif.
        /// </summary>
        FACULTATIVE,

        /// <summary>
        ///     Encadrement par des parenthèses.
        /// </summary>
        PARENTHESIS
    }

    /// <summary>
    ///     Enveloppe.
    ///     Noeud constitutif d'un arbre syntaxique SQL et doté d'un
    ///     sous-composant auquel il applique un comportement pré-défini.
    /// </summary>
    internal class WrapperToken : AbstractToken
    {
        /// <summary>
        ///     Type d'enveloppe.
        /// </summary>
        internal WrapperTokenType Type { get; set; }

        /// <summary>
        ///     Elément interne.
        /// </summary>
        internal AbstractToken Inner { get; set; }
    }
}
