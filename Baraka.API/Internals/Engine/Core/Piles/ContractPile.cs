namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Racine de pile.
    ///     Processeur situé à la racine d'une pile.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractPile<TContract> : IContractProcessor<TContract>
        where TContract : IContract
    {
    }

    /// <summary>
    ///     Racine de pile.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat traité.</typeparam>
    internal class ContractPile<TContract> : ContractProcessor<TContract>, IContractPile<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     <see cref="IContractProcessor{TContract}.Inject(TContract)" />
        /// </summary>
        public override IContractStack Inject(TContract contract)
        {
            return new ContractStack();
        }
    }
}
