namespace Baraka.API.Internals.Engine.Syntax.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Baraka.API.Internals.Engine.Syntax.Instructions;
    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Modèle syntaxique.
    ///     Expression régulière permettant la reconnaissance d'un
    ///     noeud de syntaxe au sein d'un document de spécification.
    /// </summary>
    /// <typeparam name="TBuild">Type d'élément généré.</typeparam>
    internal abstract class AbstractSyntaxPattern<TBuild>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="regex">Expression régulière.</param>
        /// <param name="builder">Générateur.</param>
        public AbstractSyntaxPattern(string regex, Func<string, TBuild> builder)
        {
            Regex = new Regex(regex);
            Build = builder;
        }

        /// <summary>
        ///     Expression régulière.
        /// </summary>
        internal Regex Regex { get; private set; }

        /// <summary>
        ///     Générateur de noeud adapté à une valeur trouvée.
        /// </summary>
        internal Func<string, TBuild> Build { get; private set; }
    }

    /// <summary>
    ///     Modèle syntaxique applicable à une instruction SQL.
    /// </summary>
    internal class InstructionSyntaxPattern : AbstractSyntaxPattern<AbstractInstruction>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="regex">Expression régulière.</param>
        /// <param name="builder">Générateur.</param>
        public InstructionSyntaxPattern(string regex, Func<string, AbstractInstruction> builder) : base(regex, builder)
        {
        }
    }

    /// <summary>
    ///     Modèle syntaxique applicable à un fragment SQL.
    /// </summary>
    internal class TokenSyntaxPattern : AbstractSyntaxPattern<AbstractToken>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="regex">Expression régulière.</param>
        /// <param name="builder">Générateur.</param>
        public TokenSyntaxPattern(string regex, Func<string, AbstractToken> builder) : base(regex, builder)
        {
        }
    }
}
