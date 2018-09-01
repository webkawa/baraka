namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Text;


    /// <summary>
    ///     Groupe de contrats.
    ///     Liste de contrats partageant un parcours similaire au sein d'une
    ///     pile de groupage, matérialisée par une liste ordonnée de classes
    ///     de groupages appliquées (voir <see cref="IContractStack" />).
    /// </summary>
    /// <typeparam name="TContract">Type des contrats compris dans le groupe.</typeparam>
    internal interface IContractGroup<TContract> : ISet<TContract>
        where TContract : IContract
    {
    }

    /// <summary>
    ///     Groupe de contrats.
    /// </summary>
    /// <typeparam name="TContract">Type des contrats compris dans le groupe.</typeparam>
    internal class ContractGroup<TContract> : HashSet<TContract>, IContractGroup<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur d'une liste sans parent.
        /// </summary>
        /// <param name="initial">Contenu initial.</param>
        public ContractGroup(TContract initial) : base()
        {
            Add(initial);
        }
    }
}
