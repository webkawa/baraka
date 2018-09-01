namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Filtre non-typé.
    /// </summary>
    internal interface IContractFilter
    {
    }

    /// <summary>
    ///     Filtre.
    ///     Processeur de contrat permettant d'évaluer si un contrat doit être, ou non, pris
    ///     en charge par le moteur à la sortie de la pile.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat évalué.</typeparam>
    internal interface IContractFilter<TContract> : IContractProcessor<TContract>
        where TContract : IContract
    {

    }

    /// <summary>
    ///     Filtre.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat évalué.</typeparam>
    internal abstract  class ContractFilter<TContract> : ContractProcessor<TContract>, IContractFilter<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="parent">Processeur parent.</param>
        public ContractFilter(IContractProcessor<TContract> parent) : base(parent)
        {
        }

        /// <summary>
        ///     <see cref="IContractProcessor{TContract}.Inject(TContract)" />
        /// </summary>
        public override IContractStack Inject(TContract contract)
        {
            var stack = Parent.Inject(contract);
            if (stack.Validated && !Validate(contract))
            {
                stack.Disable();
            }
            return stack;
        }

        /// <summary>
        ///     Valide un contrat.
        /// </summary>
        /// <param name="contract">Contrat validé.</param>
        /// <returns>true si le contrat est validé, false sinon.</returns>
        protected abstract bool Validate(TContract contract);
    }
}
