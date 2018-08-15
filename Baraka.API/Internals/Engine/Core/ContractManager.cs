﻿namespace Baraka.API.Internals.Engine.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Text;

    using Baraka.API.Exceptions;
    using Baraka.API.Internals.Engine.Contracts.Plans;
    using Microsoft.Extensions.Logging;

    /// <summary>
    ///     Orchestrateur.
    ///     Classe dédiée à la prise en charge d'un type de contrat pré-défini, de manière
    ///     asynchrone et selon une logique de priorisation propre.
    /// </summary>
    /// <typeparam name="TContract">Type de contrats traité.</typeparam>
    internal interface IContractManager<TContract> : IEngineAttached
        where TContract : IContract
    {
        /// <summary>
        ///     A l'activité d'un contrat.
        /// </summary>
        IObservable<TContract> OnContractActivity { get; }

        /// <summary>
        ///     A l'injection d'un contrat.
        /// </summary>
        IObservable<TContract> OnContractInjected { get; }

        /// <summary>
        ///     Au lancement d'un contrat.
        /// </summary>
        IObservable<TContract> OnContractRunning { get; }

        /// <summary>
        ///     A la mise en pause d'un contrat.
        /// </summary>
        IObservable<TContract> OnContractPaused { get; }

        /// <summary>
        ///     A la finalisation d'un contrat.
        /// </summary>
        IObservable<TContract> OnContractFinalized { get; }

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        ///     Injecte un contrat dans le gestionnaire pour prise en charge.
        /// </summary>
        /// <param name="contract">Contrat injecté.</param>
        /// <param name="causes">Liste des contrats à l'origine du contrat courant.</param>
        void Inject(TContract contract, params IContract[] causes);
    }

    /// <summary>
    ///     Orchestrateur.
    /// </summary>
    /// <typeparam name="TContract">Type de contrats traité.</typeparam>
    internal abstract class ContractManager<TContract> : IContractManager<TContract>
        where TContract : IContract
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        /// <param name="engine">Moteur d'appartenance.</param>
        public ContractManager(IEngine engine)
        {
            Engine = engine;
            Activity = new Subject<TContract>();
        }

        /// <summary>
        ///     Moteur propriétaire.
        /// </summary>
        public IEngine Engine { get; private set; }

        /// <summary>
        ///     A l'activité d'un contrat.
        /// </summary>
        public IObservable<TContract> OnContractActivity => Activity;

        /// <summary>
        ///     A l'injection d'un contrat.
        /// </summary>
        public IObservable<TContract> OnContractInjected => Activity.Where(e => e.CurrentStatus == ContractStatus.INJECTED);

        /// <summary>
        ///     Au lancement d'un contrat.
        /// </summary>
        public IObservable<TContract> OnContractRunning => Activity.Where(e => e.CurrentStatus == ContractStatus.RUNNING);

        /// <summary>
        ///     A la mise en pause d'un contrat.
        /// </summary>
        public IObservable<TContract> OnContractPaused => Activity.Where(e => e.CurrentStatus == ContractStatus.PAUSED);

        /// <summary>
        ///     A la finalisation d'un contrat.
        /// </summary>
        public IObservable<TContract> OnContractFinalized => Activity.Where(e => e.CurrentStatus == ContractStatus.FINALIZED);

        /// <summary>
        ///     Gestionnaire de logs.
        /// </summary>
        public ILogger Logger => Engine.Logger;

        /// <summary>
        ///     Flux d'activité des contrats.
        /// </summary>
        private ISubject<TContract> Activity { get; set; }

        /// <summary>
        ///     Injecte un contrat dans le gestionnaire pour prise en charge.
        /// </summary>
        /// <param name="contract">Contrat injecté.</param>
        /// <param name="causes">Liste des contrats à l'origine du contrat courant.</param>
        public void Inject(TContract contract, params IContract[] causes)
        {
            // Mise à jour des plans
            if (causes == null || causes.Length == 0)
            {
                var plan = contract as IPlan;
                if (plan == null)
                {
                    throw new EngineException("Injection without causes is only allowed for plan contracts");
                }
            }
            else foreach (IContract cause in causes)
            {
                Engine.PlanManager.Attach(contract, cause);
            }

            // Intégration
            contract.OnStatusChange.Subscribe((value) =>
            {
                Activity.OnNext(contract);
            });
            contract.Integrate();
        }
    }
}