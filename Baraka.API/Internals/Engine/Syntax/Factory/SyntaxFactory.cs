namespace Baraka.API.Internals.Engine.Syntax.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Syntax.Instructions;
    using Baraka.API.Internals.Engine.Syntax.Tokens;

    /// <summary>
    ///     Générateur de syntaxe.
    ///     Classe utilitaire permettant la génération d'un ou plusieurs arbres
    ///     syntaxique sur la base d'une source au format texte.
    ///     Voir : https://docs.microsoft.com/fr-fr/sql/t-sql/language-elements/transact-sql-syntax-conventions-transact-sql?view=sql-server-2017
    /// </summary>
    internal class SyntaxFactory
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public SyntaxFactory()
        {
            InstructionsPatterns = new HashSet<InstructionSyntaxPattern>();
            AddSubInstructionPattern();
            AddInstructionPattern();

            TokenPatterns = new HashSet<TokenSyntaxPattern>();
            AddFacultivePattern();
            AddMandatoryPattern();
            AddParenthesisPattern();
            AddSelectionPattern();
            AddKeywordsPattern();
            AddReferencesPattern();
            AddExpressionsPattern();
        }
        
        /// <summary>
        ///     Liste ordonnée des modèles d'instruction recherchés dans la
        ///     spécification.
        /// </summary>
        private ISet<InstructionSyntaxPattern> InstructionsPatterns { get; set; }

        /// <summary>
        ///     Liste ordonnée des modèles de fragments recherchés dans la 
        ///     spécification.
        /// </summary>
        private ISet<TokenSyntaxPattern> TokenPatterns { get; set; }
        
        /// <summary>
        ///     Traite une chaîne de spécification et retourne le fragment de
        ///     syntaxe qu'elle représente.
        /// </summary>
        /// <param name="raw">Chaîne traitée.</param>
        /// <returns>Fragment correspondant.</returns>
        internal AbstractToken ProcessToken(string raw)
        {
            foreach (TokenSyntaxPattern pattern in TokenPatterns)
            {
                if (pattern.Regex.IsMatch(raw))
                {
                    return pattern.Build(raw);
                }
            }

            throw new InternalException("Syntax factory failed to process raw token '{0}'", raw);
        }

        /// <summary>
        ///     Traite une chaîne de spécification et retourne un fragment typé
        ///     à la demande.
        /// </summary>
        /// <typeparam name="TToken">Type de fragment souhaité.</typeparam>
        /// <param name="raw">Chaîne brute.</param>
        /// <returns>Fragment typé.</returns>
        internal TToken ProcessToken<TToken>(string raw) where TToken : AbstractToken
        {
            var result = ProcessToken(raw) as TToken;
            if (result == null)
            {
                throw new InternalException("Failed to process raw specification '{0}' as '{1}'", raw, typeof(TToken));
            }

            return result;
        }

        /// <summary>
        ///     Traite une chaîne de spécification et retourne l'instruction SQL
        ///     correspondante.
        /// </summary>
        /// <param name="raw">Chaîne brute.</param>
        /// <returns>Instruction.</returns>
        internal AbstractInstruction ProcessInstruction(string raw)
        {
            foreach (InstructionSyntaxPattern pattern in InstructionsPatterns)
            {
                if (pattern.Regex.IsMatch(raw))
                {
                    return pattern.Build(raw);
                }
            }

            throw new InternalException("Syntax factory failed to process raw instruction '{0}'", raw);
        }
        
        /// <summary>
        ///     Référence un modèle de spécification applicable à une instruction SQL
        ///     dans la liste supportée par la fabrique.
        /// </summary>
        /// <param name="regex">Expression régulière.</param>
        /// <param name="builder">Générateur.</param>
        /// <returns>Modèle de spécification généré.</returns>
        private InstructionSyntaxPattern SaveInstructionPattern(string regex, Func<string, AbstractInstruction> builder)
        {
            var result = new InstructionSyntaxPattern(regex, builder);
            InstructionsPatterns.Add(result);
            return result;
        }

        /// <summary>
        ///     Référence le modèle pour les requêtes complètes.
        /// </summary>
        /// <returns>Modèle de spécification généré.</returns>
        private void AddInstructionPattern()
        {
            SaveInstructionPattern("*+", (value) =>
            {
                return new MainInstruction()
                {
                    Root = ProcessToken<ChainToken>(value.Trim())
                };
            });
        }

        /// <summary>
        ///     Reférence le modèle des sous-requêtes.
        /// </summary>
        private void AddSubInstructionPattern()
        {
            SaveInstructionPattern("<[a-z]+> *::=", (value) =>
            {
                var key = value.Substring(0, value.IndexOf("::=")).Replace("<", "").Replace(">", "").Trim();
                var sub = value.Substring(value.IndexOf("::=") + 3);
                return new SubInstruction()
                {
                    Root = ProcessToken<ChainToken>(sub.Trim()),
                    Key = key
                };
            });
        }

        /// <summary>
        ///     Ajoute un modèle de spécification applicable à un fragment dans la liste 
        ///     supportée par la fabrique.
        /// </summary>
        /// <param name="regex">Expression régulière.</param>
        /// <param name="builder">Générateur.</param>
        /// <returns>Modèle de spécification généré.</returns>
        private TokenSyntaxPattern SaveTokenPattern(string regex, Func<string, AbstractToken> builder)
        {
            var result = new TokenSyntaxPattern(regex, builder);
            TokenPatterns.Add(result);
            return result;
        }

        /// <summary>
        ///     Référence le modèle pour les noeuds facultatifs.
        /// </summary>
        private void AddFacultivePattern()
        {
            SaveTokenPattern(@"\[.+\]", (value) =>
            {
                string sub = value.Substring(1, value.Length - 2).Trim();
                return new WrapperToken()
                {
                    Type = WrapperTokenType.FACULTATIVE,
                    Inner = ProcessToken(sub)
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les noeuds obligatoires.
        /// </summary>
        private void AddMandatoryPattern()
        {
            SaveTokenPattern(@"\{.+\}", (value) =>
            {
                string sub = value.Substring(1, value.Length - 2).Trim();
                return new WrapperToken()
                {
                    Type = WrapperTokenType.MANDATORY,
                    Inner = ProcessToken(sub)
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour noeuds entre parenthèses.
        /// </summary>
        private void AddParenthesisPattern()
        {
            SaveTokenPattern(@"\(.+\)", (value) =>
            {
                string sub = value.Substring(1, value.Length - 2).Trim();
                return new WrapperToken()
                {
                    Type = WrapperTokenType.PARENTHESIS,
                    Inner = ProcessToken(sub)
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les noeuds de sélection.
        /// </summary>
        private void AddSelectionPattern()
        {
            SaveTokenPattern(@".+(\|.+)", (value) =>
            {
                string[] split = value.Split("|");
                return new ChainToken()
                {
                    Mode = ChainTokenMode.SELECT,
                    Children = split.Select(e => ProcessToken(e.Trim())).ToList()
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les mots-clefs.
        /// </summary>
        private void AddKeywordsPattern()
        {
            SaveTokenPattern("[A-Z]+", (value) =>
            {
                return new KeywordToken()
                {
                    Value = value
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les références.
        /// </summary>
        private void AddReferencesPattern()
        {
            SaveTokenPattern("<[a-z_]+>", (value) =>
            {
                string sub = value.Substring(1, value.Length - 2).Trim();
                return new WrapperToken()
                {
                    Type = WrapperTokenType.MANDATORY,
                    Inner = ProcessToken(sub)
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les expressions.
        /// </summary>
        private void AddExpressionsPattern()
        {
            SaveTokenPattern("[a-z_]+", (value) =>
            {
                return new StatementToken()
                {
                    Name = value.Trim()
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les chaînes simples.
        /// </summary>
        private void AddChainPattern()
        {
            SaveTokenPattern("[.\n]+", (value) =>
            {
                // Division d'une chaîne en sous-enfants
                IList<string> children = new List<string>();
                string buff = string.Empty;
                char? wait = null; // Caractère attendu pour cesser l'enregistrement
                foreach (char c in value)
                {
                    if (wait.HasValue)
                    {
                        if (c == wait.Value)
                        {
                            children.Add(buff);
                            wait = null;
                            buff = string.Empty;
                        }
                        else
                        {
                            buff += c;
                        }
                    }
                    else
                    {
                        switch (c)
                        {
                            case ' ':
                            case '\n':
                                break; // Bypass
                            case '[': wait = ']'; break;
                            case '{': wait = '}'; break;
                            case '(': wait = ')'; break;
                            default: wait = ' '; break;
                        }
                    }
                }

                return new ChainToken()
                {
                    Mode = ChainTokenMode.CONCAT,
                    Children = children.Select(e => ProcessToken(e)).ToList()
                };
            });
        }
    }
}
