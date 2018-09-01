namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Groupes de contrat.
    ///     Ensemble de groupes de contrats classés par parcours respectif.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractGroups<TContract> : IDictionary<IContractStack, IContractGroup<TContract>>
        where TContract : IContract
    {
        /// <summary>
        ///     Pousse un contrat unitaire dans le groupe.
        /// </summary>
        /// <param name="key">Clef d'accès au contrat.</param>
        /// <param name="value">Contrat.</param>
        void Push(IContractStack key, TContract value);

        /// <summary>
        ///     Retire un contrat unitaire du groupe.
        /// </summary>
        /// <param name="key">Clef d'accès au contrat.</param>
        /// <param name="value">Contrat.</param>
        void Pull(IContractStack key, TContract value);
    }

    /// <summary>
    ///     Groupes de contrat.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal class ContractGroups<TContract> : Dictionary<IContractStack, IContractGroup<TContract>>, IContractGroups<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     <see cref="IContractGroups{TContract}.Push(IContractStack, TContract)" />
        /// </summary>
        public void Push(IContractStack key, TContract value)
        {
            if (ContainsKey(key))
            {
                // Ajout à une entrée pré-existante du tampon
                this[key].Add(value);
            }
            else
            {
                // Création d'une entrée dans le tampon
                var group = new ContractGroup<TContract>(value);
                Add(key, group);
            }
        }

        /// <summary>
        ///     <see cref="IContractGroups{TContract}.Pull(IContractStack, TContract)" />
        /// </summary>
        public void Pull(IContractStack key, TContract value)
        {
            if (ContainsKey(key))
            {
                this[key].Remove(value);
                if (this[key].Count == 0)
                {
                    Remove(key);
                }
            }
        }
    }
}
