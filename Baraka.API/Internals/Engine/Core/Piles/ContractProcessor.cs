namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    /// <summary>
    ///     Processeur non-typé.
    /// </summary>
    internal interface IContractProcessor
    {
        /// <summary>
        ///     Racine de la pile.
        /// </summary>
        IContractProcessor Root { get; }
    }

    /// <summary>
    ///     Processeur.
    ///     Classe dédiée à la classification, au filtrage et à la restitution 
    ///     d'instances d'un type de contrat donnée.
    ///     Le processeur inclut une référence - facultative et définie dès
    ///     l'instanciation - vers un processeur parent. Une liste de processeurs
    ///     liés de la sorte constituent une pile, dans laquelle des traitements
    ///     peuvent être injectés.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractProcessor<TContract> : IContractProcessor
        where TContract : IContract
    {
        /// <summary>
        ///     Processeur parent.
        /// </summary>
        IContractProcessor<TContract> Parent { get; }

        /// <summary>
        ///     Injecte un contrat unitaire à travers le processeur et retourne
        ///     le parcours suivi dans les processeurs parents et courant.
        /// </summary>
        /// <param name="contract">Contrat injecté.</param>
        /// <returns>Parcours du contrat.</returns>
        IContractStack Inject(TContract contract);
    }

    /// <summary>
    ///     Processeur.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal abstract class ContractProcessor<TContract> : IContractProcessor<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur racine.
        /// </summary>
        public ContractProcessor()
        {
        }

        /// <summary>
        ///     Constructeur à parent.
        /// </summary>
        /// <param name="parent">Répartisseur parent.</param>
        public ContractProcessor(IContractProcessor<TContract> parent) : base()
        {
            Parent = parent;
        }

        /// <summary>
        ///     Pile parente.
        /// </summary>
        public IContractProcessor<TContract> Parent { get; private set; }

        /// <summary>
        ///     Pile racine.
        /// </summary>
        public IContractProcessor Root => Parent.Root ?? this;

        /// <summary>
        ///     <see cref="IContractProcessor{TContract}.Inject(TContract)" />
        /// </summary>
        public abstract IContractStack Inject(TContract contract);
    }
}
