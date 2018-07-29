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
            AddRepetitivePattern();
            AddFacultivePattern();
            AddMandatoryPattern();
            AddParenthesisPattern();
            AddSelectionPattern();
            AddKeywordsPattern();
            AddReferencesPattern();
            AddExpressionsPattern();
            AddChainPattern();
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
                if (pattern.Evaluate(raw))
                {
                    var build = pattern.Build(raw);
                    build.Source = raw;
                    return build;
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
        internal IInstruction ProcessInstruction(string raw)
        {
            foreach (InstructionSyntaxPattern pattern in InstructionsPatterns)
            {
                if (pattern.Evaluate(raw))
                {
                    return pattern.Build(raw);
                }
            }

            throw new InternalException("Syntax factory failed to process raw instruction '{0}'", raw);
        }

        /// <summary>
        ///     Indique si une chaîne de caractère représente un ensemble encadré par deux
        ///     caractères-clef.
        /// </summary>
        /// <param name="value">Valeur évaluée.</param>
        /// <param name="begin">Caractère de départ.</param>
        /// <param name="end">Caractère de fin.</param>
        /// <returns>true si la chaîne de caractère est encadrée, false sinon.</returns>
        private static bool IsDelimitedBy(string value, char begin, char end)
        {
            if (value.StartsWith(begin) && value.EndsWith(end))
            {
                int buff = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == begin) buff++;
                    if (value[i] == end) buff--;
                    if (buff == 0) return i == value.Length - 1;
                }
            }

            return false;
        }
        
        /// <summary>
        ///     Référence un modèle de spécification applicable à une instruction SQL
        ///     dans la liste supportée par la fabrique.
        /// </summary>
        /// <param name="evaluator">Fonction d'évaluation.</param>
        /// <param name="builder">Générateur.</param>
        /// <returns>Modèle de spécification généré.</returns>
        private InstructionSyntaxPattern SaveInstructionPattern(Func<string, bool> evaluator, Func<string, IInstruction> builder)
        {
            var result = new InstructionSyntaxPattern(evaluator, builder);
            InstructionsPatterns.Add(result);
            return result;
        }

        /// <summary>
        ///     Référence le modèle pour les requêtes complètes.
        /// </summary>
        /// <returns>Modèle de spécification généré.</returns>
        private void AddInstructionPattern()
        {
            SaveInstructionPattern((value) => true, (value) =>
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
            var regex = new Regex("<[A-Za-z_ ]+> *::=");
            SaveInstructionPattern((value) => regex.IsMatch(value), (value) =>
            {
                var key = value.Substring(0, value.IndexOf("::=")).Replace("<", "").Replace(">", "").Trim();
                var sub = value.Substring(value.IndexOf("::=") + 3);
                return new SubInstruction()
                {
                    Root = ProcessToken(sub.Trim()),
                    Key = key
                };
            });
        }

        /// <summary>
        ///     Ajoute un modèle de spécification applicable à un fragment dans la liste 
        ///     supportée par la fabrique.
        /// </summary>
        /// <param name="evaluator">Fonction d'évaluation.</param>
        /// <param name="builder">Générateur.</param>
        /// <returns>Modèle de spécification généré.</returns>
        private TokenSyntaxPattern SaveTokenPattern(Func<string, bool> evaluator, Func<string, AbstractToken> builder)
        {
            var result = new TokenSyntaxPattern(evaluator, builder);
            TokenPatterns.Add(result);
            return result;
        }

        /// <summary>
        ///     Référence la modèle pour les noeuds de répétition.
        /// </summary>
        private void AddRepetitivePattern()
        {
            var regex = new Regex(@"^\[ *,?\.\.\.n *\]$");
            SaveTokenPattern(
                (value) => regex.IsMatch(value),
                (value) =>
                {
                    return new RepetitiveToken()
                    {
                        Separator = value.Contains(",") ? true : false
                    };
                });
        }

        /// <summary>
        ///     Référence le modèle pour les noeuds facultatifs.
        /// </summary>
        private void AddFacultivePattern()
        {
            SaveTokenPattern(
                (value) => IsDelimitedBy(value, '[', ']'), 
                (value) =>
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
            SaveTokenPattern(
                (value) => IsDelimitedBy(value, '{', '}'),
                (value) =>
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
            SaveTokenPattern(
                (value) => IsDelimitedBy(value, '(', ')'),
                (value) =>
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
            SaveTokenPattern(
                (value) =>
                {
                    int buff = 0;
                    foreach (char c in value)
                    {
                        switch (c)
                        {
                            case '[':
                            case '{':
                            case '(':
                                buff++;
                                break;

                            case ']':
                            case '}':
                            case ')':
                                buff--;
                                break;

                            case '|':
                                if (buff == 0) return true;
                                break;

                            default: break;
                        }
                    }

                    return false;
                },
                (value) =>
                {
                    IList<string> split = new List<string>();
                    string buff = string.Empty;
                    int level = 0;
                    foreach (char c in value)
                    {
                        buff += c;
                        switch (c)
                        {
                            case '|':
                                if (level == 0)
                                {
                                    split.Add(buff.Substring(0, buff.Length - 1));
                                    buff = string.Empty;
                                }
                                break;

                            case '[':
                            case '{':
                            case '(':
                                level++;
                                break;

                            case ']':
                            case '}':
                            case ')':
                                level--;
                                break;
                        }
                    }
                    split.Add(buff);

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
            var regex = new Regex(@"^([A-Z]+|;|\.)$");
            SaveTokenPattern((value) => regex.IsMatch(value), (value) =>
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
            var regex = new Regex("^<[A-Za-z_ ]+>$");
            SaveTokenPattern((value) => regex.IsMatch(value), (value) =>
            {
                string sub = value.Substring(1, value.Length - 2).Trim();
                return new ReferenceToken()
                {
                    Key = sub
                };
            });
        }

        /// <summary>
        ///     Référence le modèle pour les expressions.
        /// </summary>
        private void AddExpressionsPattern()
        {
            var regex = new Regex("^[a-z_]+$");
            SaveTokenPattern((value) => regex.IsMatch(value), (value) =>
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
            var regex = new Regex(@"[.\w\r\n]+");
            SaveTokenPattern((value) => regex.IsMatch(value), (value) =>
            {
                // Division d'une chaîne en sous-enfants
                IList<string> children = new List<string>();
                string buff = string.Empty;

                int frameLevel = 0;
                char? frameStart = null;
                char? frameEnd = null;

                for (int i = 0; i < value.Length; i++)
                {
                    buff += value[i];
                    if (frameEnd.HasValue)
                    {
                        if (frameStart.HasValue && value[i] == frameStart.Value) frameLevel++;
                        else if (value[i] == frameEnd.Value) frameLevel--;
                        if (frameLevel == 0 || i == value.Length - 1)
                        {
                            frameStart = null;
                            frameEnd = null;

                            children.Add(buff.Trim());
                            buff = string.Empty;
                        }
                    }
                    else
                    {
                        switch (value[i])
                        {
                            case ' ':
                            case '\n':
                            case '\r':
                                // Bypass
                                break;

                            case '.':
                                children.Add(".");
                                buff = string.Empty;
                                break;

                            case '[':
                                frameStart = '[';
                                frameEnd = ']';
                                break;

                            case '{':
                                frameStart = '{';
                                frameEnd = '}';
                                break;

                            case '(':
                                frameStart = '(';
                                frameEnd = ')';
                                break;

                            default:
                                frameEnd = ' ';
                                break;
                        }

                        if (frameEnd.HasValue)
                        {
                            frameLevel = 1;
                            buff = string.Empty + value[i];
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
