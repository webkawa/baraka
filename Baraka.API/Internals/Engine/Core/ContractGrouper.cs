namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Classe de groupage non-typée.
    /// </summary>
    internal interface IContractGrouper
    {
    }

    /// <summary>
    ///     Classe de groupage.
    ///     Classe rattachée à un type de contrat et permettant d'en grouper une ou plusieurs
    ///     instances dans une sous-liste, généralement de taille restreinte.
    ///     La classe s'appuie sur une fonction de réduction permettant la prise en charge
    ///     d'une liste de contrats du type géré, ainsi que sur les méthodes "Equals()" et
    ///     "HashCode()" pour la comparaison de deux instances d'un même groupe.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat groupé.</typeparam>
    internal interface IContractGrouper<TContract> : IContractGrouper
        where TContract : IContract
    {
        /// <summary>
        ///     Réduit une liste de contrats en une sous-liste représentative du
        ///     groupe.
        /// </summary>
        /// <param name="group">Groupe traité.</param>
        /// <returns>Sous-groupe.</returns>
        ISet<TContract> Reduce(ISet<TContract> group);
    }

    /// <summary>
    ///     Classe de groupage.
    /// </summary>
    /// <typeparam name="TContract">Type de contrats groupés.</typeparam>
    internal abstract class ContractGrouper<TContract> : IContractGrouper<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="logger">Classe de loggage.</param>
        public ContractGrouper(ILogger logger)
        {
            Logger = logger;
        }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        ///     <see cref="IContractGrouper{TContract}.Reduce(ISet{TContract})" />
        /// </summary>
        public abstract ISet<TContract> Reduce(ISet<TContract> group);
    }
}
