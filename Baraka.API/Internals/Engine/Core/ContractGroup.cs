namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Text;


    /// <summary>
    ///     Groupe de contrats.
    ///     Liste de contrats partageant un parcours similaire au sein d'une
    ///     pile de groupage, matérialisée par une liste ordonnée de classes
    ///     de groupages appliquées.
    /// </summary>
    /// <typeparam name="TContract">Type des contrats compris dans le groupe.</typeparam>
    internal interface IContractGroup<TContract> : ISet<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Pile de groupage.
        /// </summary>
        IList<IContractGrouper> Stack { get; }
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
        /// <param name="grouper">Classe de groupage.</param>
        /// <param name="initial">Contenu initial.</param>
        public ContractGroup(IContractGrouper<TContract> grouper, IEnumerable<TContract> initial) : base(initial)
        {
            Stack = new List<IContractGrouper>()
            {
                grouper
            };
        }

        /// <summary>
        ///     Constructeur d'une liste à précédents.
        /// </summary>
        /// <param name="grouper">Classe de groupage.</param>
        /// <param name="initial">Contenu initial.</param>
        /// <param name="precedents">Groupeur précédents.</param>
        public ContractGroup(IContractGrouper<TContract> grouper, IEnumerable<TContract> initial, IList<IContractGrouper> precedents): base(initial)
        {
            Stack = new List<IContractGrouper>(precedents);
            Stack.Add(grouper);
        }

        /// <summary>
        ///     Pile de groupage.
        /// </summary>
        public IList<IContractGrouper> Stack { get; private set; }
    }
}
