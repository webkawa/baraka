namespace Baraka.API.Internals.Engine.Contracts.Plans
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Priorité d'exécution.
    /// </summary>
    internal enum PlanPriority
    {
        /// <summary>
        ///     Exécution immédiate.
        /// </summary>
        IMMEDIATE,

        /// <summary>
        ///     Exécution dès disponibilité.
        /// </summary>
        ASAP,

        /// <summary>
        ///     Exécution au plus tard.
        /// </summary>
        LAZY
    }

    /// <summary>
    ///     Options appliquées à un plan d'exécution.
    /// </summary>
    internal class PlanOptions
    {
        /// <summary>
        ///     Priorité du plan.
        /// </summary>
        internal PlanPriority Priority { get; set; }

        /// <summary>
        ///     Transaction unique.
        /// </summary>
        internal bool Transactional { get; set; }
    }
}
