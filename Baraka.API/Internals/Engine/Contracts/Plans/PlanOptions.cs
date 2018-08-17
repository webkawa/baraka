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
    internal interface IPlanOptions
    {
        /// <summary>
        ///     Priorité du plan.
        /// </summary>
        PlanPriority Priority { get; }
    }

    /// <summary>
    ///     Options appliquées à un plan d'exécution.
    /// </summary>
    internal class PlanOptions : IPlanOptions
    {
        /// <summary>
        ///     Priorité du plan.
        /// </summary>
        public PlanPriority Priority { get; set; }
    }
}
