namespace Baraka.API.Internals.Engine.Core.Dispatch
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Core.Piles;

    /// <summary>
    ///     Répartisseur sur périmètre.
    ///     Classe de répartition prenant pour critère de discrimination un objet porté par le
    ///     contrat lui-même.
    /// </summary>
    /// <typeparam name="TContract">Type du contrat.</typeparam>
    internal class ScopeDispatcher<TContract> : ContractDispatcher<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="parent">Répartisseur parent.</param>
        /// <param name="accessor">Accesseur.</param>
        public ScopeDispatcher(IContractPile<TContract> parent, Func<TContract, object> accessor) : base(parent)
        {
            Accessor = accessor;
        }

        /// <summary>
        ///     Accesseur.
        ///     Méthode d'accès à l'objet de comparaison.
        /// </summary>
        private Func<TContract, object> Accessor { get; set; }

        /// <summary>
        ///     <see cref="ContractDispatcher{TContract}.Extract(TContract)" />
        /// </summary>
        protected override IContractGrouper Extract(TContract contract)
        {
            var key = Accessor(contract);
            return new ScopeGrouper(key);
        }
    }
}
