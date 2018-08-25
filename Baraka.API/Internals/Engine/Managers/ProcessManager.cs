namespace Baraka.API.Internals.Engine.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Processes;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Gestionnaire de processus.
    ///     Gestionnaire chargé de l'organisation et de la répartition des processus
    ///     métier de l'application. Les processus sont traités parallèlement sur la base 
    ///     d'un mécanisme de pool de taille fixe.
    /// </summary>
    internal class ProcessManager : ContractManager<IProcess>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur applicatif.</param>
        public ProcessManager(Engine engine) : base(engine)
        {
            OnContractInjected.Subscribe((process) =>
            {
                process.Launch();
            });
        }
    }
}
