namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Groupes de contrat.
    ///     Ensemble de groupes de contrats classés par classe de groupage.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal interface IContractGroups<TContract> : IDictionary<IContractGrouper<TContract>, IContractGroup<TContract>>
        where TContract : IContract
    {
    }

    /// <summary>
    ///     Groupes de contrat.
    /// </summary>
    /// <typeparam name="TContract">Type de contrat géré.</typeparam>
    internal class ContractGroups<TContract> : Dictionary<IContractGrouper<TContract>, IContractGroup<TContract>>, IContractGroups<TContract>
        where TContract : IContract
    {
    }
}
