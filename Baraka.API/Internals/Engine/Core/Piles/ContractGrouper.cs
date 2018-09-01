namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Classe de groupage.
    ///     Classe rattachée à un type de contrat et permettant d'en grouper une ou plusieurs
    ///     instances dans une sous-liste, généralement de taille restreinte. La classe s'appuie
    ///     sur les méthodes "Equals()" et "GetHashCode()" pour procéder au groupage.
    /// </summary>
    internal interface IContractGrouper
    {
    }

    /// <summary>
    ///     Classe de réduction.
    ///     Classe de groupage implémentant une fonction de réduction et pouvant à ce titre
    ///     être utilisée en sortie d'un répartisseur.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat groupé.</typeparam>
    internal interface IContractReducer<TContract> : IContractGrouper
        where TContract : IContract
    {
        /// <summary>
        ///     Réduit une liste de contrats en un sous-contrat représentatif du
        ///     groupe.
        /// </summary>
        /// <param name="group">Groupe traité.</param>
        /// <returns>Sous-groupe.</returns>
        TContract Reduce(ISet<TContract> group);
    }

    /// <summary>
    ///     Classe de groupage.
    /// </summary>
    internal abstract class ContractGrouper : IContractGrouper
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public ContractGrouper()
        {
        }

        /// <summary>
        ///     <see cref="Object.Equals(object)" />
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as IContractGrouper;
            return other != null && Compare(other);
        }

        /// <summary>
        ///     <see cref="Object.GetHashCode()" />
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode();
        }

        /// <summary>
        ///     Compare la classe de groupage à une autre.
        /// </summary>
        /// <param name="other">Objet comparé.</param>
        /// <returns>true si les deux objets sont équivalents, false sinon.</returns>
        protected abstract bool Compare(IContractGrouper other);

        /// <summary>
        ///     Retourne le code rattaché à la classe.
        /// </summary>
        /// <returns>Code de haschage.</returns>
        protected abstract int HashCode();
    }

    /// <summary>
    ///     Classe de réduction.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat réduit.</typeparam>
    internal abstract class ContractReducer<TContract> : IContractReducer<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     <see cref="IContractReducer{TContract}.Reduce(ISet{TContract})" />
        /// </summary>
        public abstract TContract Reduce(ISet<TContract> group);
    }
}
