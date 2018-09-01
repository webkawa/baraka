namespace Baraka.API.Internals.Engine.Core.Dispatch
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Core.Piles;

    /// <summary>
    ///     Classe de groupage basée sur la comparaison d'une instance d'un 
    ///     objet tiers.
    /// </summary>
    internal class ScopeGrouper : ContractGrouper
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="key">Clef d'accès.</param>
        public ScopeGrouper(object key)
        {
            Key = key;
        }

        /// <summary>
        ///     Clef du groupage.
        /// </summary>
        private object Key { get; set; }

        /// <summary>
        ///     <see cref="ContractGrouper.Compare(IContractGrouper)" />
        /// </summary>
        protected override bool Compare(IContractGrouper other)
        {
            var obj = other as ScopeGrouper;
            return obj != null && obj.Key == Key;
        }

        /// <summary>
        ///     <see cref="ContractGrouper.HashCode()" />
        /// </summary>
        protected override int HashCode()
        {
            return Key.GetHashCode();
        }
    }
}
