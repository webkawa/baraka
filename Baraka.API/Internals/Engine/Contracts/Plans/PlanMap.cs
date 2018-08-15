namespace Baraka.API.Internals.Engine.Contracts.Plans
{
    using Baraka.API.Internals.Engine.Core;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Cartographie d'un plan d'exécution.
    ///     Classe utilitaire permettant l'établissement d'une cartographie
    ///     entre les différents traitements exécutés dans le cadre d'un plan
    ///     d'exécution. Les liaisons entre contrats sont établies sous la forme 
    ///     d'un arbre de dépendances représentant les liens de causalité entre 
    ///     les différents contrats figuant dans la cartographie.
    /// </summary>
    internal class PlanMap
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PlanMap(IPlan root)
        {
            Root = new PlanMapNode(this, root);
        }

        /// <summary>
        ///     Racine de la carte.
        /// </summary>
        internal PlanMapNode Root { get; private set; }

        /// <summary>
        ///     Point d'accès à l'index.
        /// </summary>
        /// <param name="contract">Contrat recherché.</param>
        /// <returns>Noeud correspondant.</returns>
        internal PlanMapNode this[IContract contract]
        {
            get
            {
                return Index[contract];
            }
            set
            {
                Index[contract] = value;
            }
        }

        /// <summary>
        ///     Plan d'appartenance.
        /// </summary>
        internal IPlan Plan => (IPlan)Root.Contract;

        /// <summary>
        ///     Index des noeuds.
        /// </summary>
        private IDictionary<IContract, PlanMapNode> Index { get; set; }
        
        /// <summary>
        ///     Procède à l'ajout d'un contrat dans la cartographie, sous réserve
        ///     que la cause correspondante soit déjà référencée.
        /// </summary>
        /// <param name="item">Elément ajouté.</param>
        /// <param name="cause">Cause.</param>
        internal void Save(IContract item, IContract cause)
        {
            if (Index.ContainsKey(item))
            {
                var add = new PlanMapNode(Index[item], item);
                Index.Add(item, add);
            }
        }
    }

    /// <summary>
    ///     Noeud.
    ///     Classe descriptive d'un contrat référencé dans une cartographie de
    ///     plan d'exécution.
    /// </summary>
    internal class PlanMapNode
    {
        /// <summary>
        ///     Constructeur du noeud racine.
        /// </summary>
        /// <param name="map">Carte d'appartenance.</param>
        /// <param name="contract">Contrat lié au noeud.</param>
        public PlanMapNode(PlanMap map, IContract contract)
        {
            Map = map;
            Contract = contract;
            Children = new HashSet<PlanMapNode>();
        }

        /// <summary>
        ///     Constructeur d'un noeud fils.
        /// </summary>
        /// <param name="parent">Noeud parent.</param>
        /// <param name="contract">Contrat lié au noeud.</param>
        public PlanMapNode(PlanMapNode parent, IContract contract) : this(parent.Map, contract)
        {
            Parent = parent;
            Parent.Children.Add(this);
        }

        /// <summary>
        ///     Carte d'appartenance.
        /// </summary>
        internal PlanMap Map { get; private set; }

        /// <summary>
        ///     Contrat lié.
        /// </summary>
        internal IContract Contract { get; private set; }

        /// <summary>
        ///     Noeud parent.
        ///     Représente la cause d'existance du contrat courant au
        ///     sein de la cartographie.
        /// </summary>
        internal PlanMapNode Parent { get; private set; }

        /// <summary>
        ///     Liste des noeuds enfants.
        /// </summary>
        internal ISet<PlanMapNode> Children { get; private set; }

        /// <summary>
        ///     Racine de la carte.
        /// </summary>
        internal PlanMapNode Root => Map.Root;

        /// <summary>
        ///     Plan d'appartenance.
        /// </summary>
        internal IPlan Plan => (IPlan)Root.Contract;
    }
}
