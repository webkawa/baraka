namespace Baraka.API.Internals.Engine.Contracts.Instructions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Instructions.Queries;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Instruction.
    ///     Requête représentée sous la forme d'un arbre logique, restituable sous
    ///     la forme de code SQL natif ou simplifié et exécutable auprès de la base
    ///     de données.
    /// </summary>
    internal interface IInstruction : IContract
    {
    }

    /// <summary>
    ///     Instruction.
    /// </summary>
    internal class Instruction : Contract, IInstruction
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public Instruction(IEngine engine) : base(engine)
        {
        }

        /// <summary>
        ///     Requête.
        /// </summary>
        private IQuery Query { get; set; }
    }
}
