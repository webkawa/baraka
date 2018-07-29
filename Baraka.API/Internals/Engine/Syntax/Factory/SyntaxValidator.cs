namespace Baraka.API.Internals.Engine.Syntax.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Baraka.API.Internals.Engine.Syntax.Instructions;

    /// <summary>
    ///     Validateur de syntaxe.
    ///     Classe dédiée à l'évaluation et à la validation d'expressions SQL sur
    ///     la base des spécifications Microsoft.
    /// </summary>
    public class SyntaxValidator
    {
        /// <summary>
        ///     Expression régulière utilisée pour l'extraction des instructions
        ///     et sous-instructions.
        /// </summary>
        private readonly Regex REGEX_SPLIT = new Regex("(\r\n){2,}");

        /// <summary>
        ///     Constructeur.
        /// </summary>
        public SyntaxValidator()
        {
            Factory = new SyntaxFactory();
            Instructions = new Dictionary<string, MainInstruction>();
            SubInstructions = new Dictionary<string, SubInstruction>();
        }

        /// <summary>
        ///     Constructeur.
        /// </summary>
        private SyntaxFactory Factory { get; set; }

        /// <summary>
        ///     Liste des instructions supportées, classées par premier mot
        ///     clef SQL.
        /// </summary>
        private IDictionary<string, MainInstruction> Instructions { get; set; }

        /// <summary>
        ///     Liste des sous-instructions supportées, classées par dénomination
        ///     dans les spécifications.
        /// </summary>
        private IDictionary<string, SubInstruction> SubInstructions { get; set; }
        
        /// <summary>
        ///     Chargement d'une chaîne de caractère brute.
        /// </summary>
        /// <param name="raw">Chaîne chargée.</param>
        public void Load(string raw)
        {
            string[] split = REGEX_SPLIT.Split(raw);
            IList<string> transform = split
                .Select(e => e.Replace("\n", ""))
                .Select(e => e.Replace("\r", ""))
                .Select(e => e.Trim())
                .Where(e => !string.IsNullOrEmpty(e))
                .Where(e => !e.StartsWith("--"))
                .ToList();

            foreach (string sub in transform)
            {
                var inst = Factory.ProcessInstruction(sub);
                if (inst is MainInstruction)
                {
                    var main = inst as MainInstruction;
                    Instructions.Add(main.Keyword.Value, main);
                }
                else
                {
                    var subins = inst as SubInstruction;
                    SubInstructions.Add(subins.Key, subins);
                }
            }
        }
    }
}
