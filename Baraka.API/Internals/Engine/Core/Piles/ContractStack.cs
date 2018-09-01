namespace Baraka.API.Internals.Engine.Core.Piles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Trajectoire.
    ///     Liste ordonnée représentative de la trajectoire suivie par un contrat
    ///     lors de sa prise en charge par une pile.
    ///     Une trajectoire est formée d'une liste de classe de groupage représentative
    ///     des différents répartisseurs traversés lors du parcours de la pile ; chaque
    ///     noeud représente le groupe assigné au contrat lors de son passage dans le
    ///     répartisseur. Une trajectoire peut par ailleurs être invalidée, entrainant
    ///     l'annulation du contrat.
    /// </summary>
    internal interface IContractStack : IList<IContractGrouper>
    {
        /// <summary>
        ///     Indique si la trajectoire a été validée.
        /// </summary>
        bool Validated { get; }

        /// <summary>
        ///     Permet la désactivation de la trajectoire.
        /// </summary>
        void Disable();
    }

    /// <summary>
    ///     Trajectoire.
    /// </summary>
    internal class ContractStack : List<IContractGrouper>, IContractStack
    {

        /// <summary>
        ///     Constructeur complémentant une pile pré-existante.
        /// </summary>
        /// <param name="parent">Pile parente.</param>
        /// <param name="current">Classe de groupage courante.</param>
        public ContractStack(IContractStack parent, IContractGrouper current) : base(parent)
        {
            Add(current);
        }

        /// <summary>
        ///     Constructeur par copie.
        /// </summary>
        /// <param name="source">Liste d'origine.</param>
        public ContractStack(IContractStack source) : base(source)
        {
        }

        /// <summary>
        ///     Constructeur adapté à une pile comportant un élément unique.
        /// </summary>
        public ContractStack() : base()
        {
        }

        /// <summary>
        ///     Indique si la trajectoire est validée.
        /// </summary>
        public bool Validated { get; private set; }

        /// <summary>
        ///     Désactive la trajectoire.
        /// </summary>
        public void Disable()
        {
            Validated = false;
        }

        /// <summary>
        ///     Compare la pile avec un objet tiers.
        /// </summary>
        /// <param name="obj">Objet traité.</param>
        /// <returns>true si les objets sont équivalents, false sinon.</returns>
        public override bool Equals(object obj)
        {
            IContractStack other = obj as IContractStack;
            if (other == null)
            {
                return false;
            }

            return Enumerable.SequenceEqual(this, other);
        }

        /// <summary>
        ///     Retourne le code rattachable à la pile.
        /// </summary>
        /// <returns>Code de hachage.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int i = 1;
                int hash = 17;
                foreach (var grouper in this)
                {
                    hash = (hash * i) + grouper.GetHashCode();
                    i++;
                }
                return hash;
            }
        }
    }
}
