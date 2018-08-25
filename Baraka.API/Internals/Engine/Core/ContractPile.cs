namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Pile de contrats non-typée.
    /// </summary>
    internal interface IContractPile
    {
        /// <summary>
        ///     Racine de la pile.
        /// </summary>
        IContractPile Root { get; }
    }

    /// <summary>
    ///     Pile de contrats.
    ///     Liste unidirectionnelle de zones tampons à travers laquelle peuvent
    ///     être injectés des listes de contrats, à la discrétion d'un gestionnaire
    ///     porteur, sous-divisés en sous-groupes une zone après l'autre.
    ///     Par choix de design, la classe représente un chaînon unitaire de la liste
    ///     (et non, la liste complète) liée à un chaînon parent. Chaque chaînon
    ///     possède donc un ensemble de chaînons enfants, auquels il n'a pas référence.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractPile<TContract> : IContractPile
        where TContract : IContract
    {
        /// <summary>
        ///     Gestionnaire lié.
        /// </summary>
        IContractManager<TContract> Manager { get; }

        /// <summary>
        ///     Récupère la classe de groupage adaptée à un contrat donné.
        /// </summary>
        /// <param name="contract">Contrat traité.</param>
        /// <returns>Instance de la classe de groupage correspondante.</returns>
        IContractGrouper<TContract> Group(TContract contract);

        /// <summary>
        ///     Injecte une liste de contrats à travers la pile et récupère
        ///     les groupes de contrats résultants.
        /// </summary>
        /// <param name="source">Liste traitée.</param>
        /// <returns>Groupes de contrats.</returns>
        IContractGroups<TContract> Inject(IEnumerable<TContract> source);
    }

    /// <summary>
    ///     Pile de contrat fille.
    ///     Pile de contrat construite à partir d'une pile tierce.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    /// <typeparam name="TParent">Type de contrat parent.</typeparam>
    internal interface IContractPile<TContract, TParent> : IContractPile<TContract>
        where TContract : IContract, TParent
        where TParent : IContract
    {
        /// <summary>
        ///     Pile parente.
        /// </summary>
        IContractPile<TParent> Parent { get; }
    }

    
    /// <summary>
    ///     Pile de contrats racine.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal class ContractPile<TContract> : IContractPile<TContract>
        where TContract : IContract
    {
        public ContractPile(IContractManager<TContract> manager, Func<TContract, IContractGrouper<TContract>> extractor)
        {
            Manager = manager;
            Extractor = extractor;
        }

        /// <summary>
        ///     Gestionnaire rattaché.
        /// </summary>
        public IContractManager<TContract> Manager { get; private set; }

        /// <summary>
        ///     Pile racine.
        /// </summary>
        public virtual IContractPile Root => this;

        /// <summary>
        ///     Extracteur.
        ///     Fonction permettant de récupérer l'instance de la classe de
        ///     groupage correspondant à un contrat.
        /// </summary>
        private Func<TContract, IContractGrouper<TContract>> Extractor { get; set; }

        /// <summary>
        ///     <see cref="IContractPile{TContract}.Group(TContract)" />
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public IContractGrouper<TContract> Group(TContract contract)
        {
            return Extractor.Invoke(contract);
        }

        /// <summary>
        ///     <see cref="IContractPile{TContract}.Inject(IEnumerable{TContract})" />
        /// </summary>
        public virtual IContractGroups<TContract> Inject(IEnumerable<TContract> list)
        {
            var result = new ContractGroups<TContract>();
            foreach (var group in list.GroupBy(e => Group(e)))
            {
                result.Add(
                    group.Key,
                    new ContractGroup<TContract>(group.Key, group));
            }

            return result;
        }
    }

    /// <summary>
    ///     Pile de contrats fille.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    /// <typeparam name="TParent">Type de contrat parent.</typeparam>
    internal class ContractPile<TContract, TParent> : ContractPile<TContract>, IContractPile<TContract, TParent>
        where TContract : IContract, TParent
        where TParent : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="manager">Gestionnaire rattaché.</param>
        /// <param name="parent">Pile parente.</param>
        public ContractPile(IContractManager<TContract> manager, IContractPile<TParent> parent) : base(manager)
        {
            Parent = parent;
        }

        /// <summary>
        ///     Pile parente.
        /// </summary>
        public IContractPile<TParent> Parent { get; private set; }

        /// <summary>
        ///     Pile racine.
        /// </summary>
        public override IContractPile Root => Parent.Root;

        /// <summary>
        ///     <see cref="IContractPile{TContract}.Inject(IEnumerable{TContract})" />
        /// </summary>
        public override IContractGroups<TContract> Inject(IEnumerable<TContract> list)
        {
            // Récupération du groupage parent
            var parentSubs = Parent.Inject(list.Cast<TParent>());

            // Sous-division
            var result = new ContractGroups<TContract>();
            foreach (var parentSub in parentSubs)
            {
                var currentSubs = base.Inject(parentSub.Value.Cast<TContract>());
                foreach (var currentSub in currentSubs)
                {
                    // Génération de la chaîne de groupage
                    var group = new ContractGroup<TContract>(currentSub.Key, currentSub.Value, parentSub.Value.Stack);
                    result.Add(currentSub.Key, group);
                }
            }

            // Renvoi
            return result;
        }
    }
}
