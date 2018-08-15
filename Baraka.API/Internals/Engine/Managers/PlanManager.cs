namespace Baraka.API.Internals.Engine.Managers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Text;

    using Baraka.API.Internals.Engine.Contracts.Events;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Baraka.API.Internals.Engine.Contracts.Treatments;
    using Baraka.API.Internals.Engine.Core;

    /// <summary>
    ///     Gestionnaire des plans.
    ///     Classe dédiée à l'ordonnancement des plans gérés par le moteur.
    ///     Fait office de point d'entrée et de sortie principal pour toutes
    ///     les classes externes.
    /// </summary>
    internal interface IPlanManager : IContractManager<IPlan>
    {
        /// <summary>
        ///     Procède à la mise à jour des cartographies des plans actifs
        ///     dans le gestionnaire de manière à rattacher un traitement donné
        ///     à un autre (cause).
        /// </summary>
        /// <param name="contrat">Contrat rattaché.</param>
        /// <param name="cause">Contrat cause.</param>
        void Attach(IContract contrat, IContract cause);
    }

    /// <summary>
    ///     Gestionnaire des plans.
    /// </summary>
    internal class PlanManager : ContractManager<IPlan>, IPlanManager
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur d'appartenance.</param>
        public PlanManager(IEngine engine) : base(engine)
        {
            Buffer = new HashSet<IPlan>();
            OnContractInjected.Subscribe((contract) =>
            {
                // Gestion de l'index
                contract
                    .OnRun
                    .Subscribe((status) =>
                    {
                        Buffer.Add(contract);
                    });

                contract
                    .OnFinalized
                    .Subscribe((result) =>
                    {
                        Buffer.Remove(contract);
                    });

                // Mise en attente de la charge initiale
                contract
                    .OnStarterFinalized
                    .Subscribe((results) =>
                    {
                        contract.Finalize(ContractResult.SUCCESS);
                    });

                // Lancement 
                contract.Run();

                // Injection
                foreach (Treatment treatment in contract.Starter.Treatments)
                {
                    Engine.TreatmentManager.Inject(treatment);
                }
                foreach (Event evt in contract.Starter.Events)
                {
                    Engine.EventManager.Inject(evt);
                }
            });
        }


        /// <summary>
        ///     Inscription d'un contrat.
        ///     Procède au référencement d'un contrat en aval de sa ou ses causes
        ///     dans les différentes cartographies de plans en cours d'exécution
        ///     concernés
        /// </summary>
        /// <param name="contract">Contrat rattaché.</param>
        /// <param name="cause">Contrat cause.</param>
        public void Attach(IContract contract, IContract cause)
        {
            lock (Buffer)
            {
                foreach (IPlan buff in Buffer)
                {
                    buff.Map.Save(contract, cause);
                }
            }
        }

        /// <summary>
        ///     Tampon.
        ///     Liste regroupant tous les plans en cours d'exécution par le
        ///     moteur.
        /// </summary>
        private ISet<IPlan> Buffer { get; set; }
    }
}
