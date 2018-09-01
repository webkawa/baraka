namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    /// <summary>
    ///     Interface des répartisseurs.
    /// </summary>
    internal interface IContractDispatcher : IContractProcessor
    {
    }

    /// <summary>
    ///     Répartisseur.
    ///     Processeur de contrats dédiés à la classification des contrats en groupes
    ///     réductibles à une instance unique.
    ///     Le répartisseur classifie les contrats qu'il prend en charge au fur et
    ///     à mesure de leur arrivée ; le résultat est stocké dans une zone tampon,
    ///     constituée d'une liste de groupes de contrat, qu'il est possible de 
    ///     requêter et de nettoyer progressivement au moyen de requêtes LINQ.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractDispatcher<TContract> : IContractDispatcher, IContractProcessor<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Zone tampon.
        /// </summary>
        IContractGroups<TContract> Buffer { get; }
    }

    /// <summary>
    ///     Répartisseur.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal abstract class ContractDispatcher<TContract> : ContractProcessor<TContract>, IContractProcessor<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="parent">Pile parente.</param>
        public ContractDispatcher(IContractProcessor<TContract> parent) : base(parent)
        {
            Buffer = new ContractGroups<TContract>();
        }

        /// <summary>
        ///     Zone tampon.
        /// </summary>
        public IContractGroups<TContract> Buffer { get; private set; }

        /// <summary>
        ///     <see cref="IContractProcessor{TContract}.Inject(TContract)" />
        /// </summary>
        public override IContractStack Inject(TContract contract)
        {
            // Récupération de la trajectoire parente
            var pre = Parent.Inject(contract);

            // Si trajectoire invalidée, fin du traitement.
            if (!pre.Validated)
            {
                return pre;
            }

            // Récupération de la classe de groupage
            var grouper = Extract(contract);

            // Définition de la nouvelle trajectoire
            IContractStack stack = new ContractStack(Parent.Inject(contract), grouper);

            // Référencement
            contract.OnRun.Subscribe((status) =>
            {
                Buffer.Pull(stack, contract);
            });
            Buffer.Push(stack, contract);

            // Renvoi
            return stack;
        }

        /// <summary>
        ///     Extracteur.
        ///     Fonction permettant de récupérer l'instance de la classe de
        ///     groupage correspondant à un contrat.
        /// </summary>
        protected abstract IContractGrouper Extract(TContract contract);
    }
}
