namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Baraka.API.DTO.Persisted.Shared;
    using Baraka.API.DTO.Persisted.Views;

    /// <summary>
    ///     Type de vue.
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        ///     Vue administrateur.
        /// </summary>
        ADMIN,

        /// <summary>
        ///     Vue en mode fiche.
        /// </summary>
        FILE,

        /// <summary>
        ///     Vue en mode liste.
        /// </summary>
        LIST,

        /// <summary>
        ///     Vue en mode SQL.
        /// </summary>
        SQL
    }

    /// <summary>
    ///     Vue.
    ///     Mode de rendu graphique et/ou fonctionnel applicable à un (ou plusieurs)
    ///     magasins de données.
    /// </summary>
    public class View : Entity
    {
        /// <summary>
        ///     Libellé.
        /// </summary>
        public virtual BundleDTO Label { get; set; }

        /// <summary>
        ///     Modèle de la vue.
        /// </summary>
        public virtual AbstractViewDTO Model { get; set; }
    }

    /// <summary>
    ///     Mappage des vues.
    /// </summary>
    public class ViewMapping : EntityMapping<View>
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public ViewMapping()
        {
            PropertyJsonFixed(e => e.Label);
            PropertyJsonGeneric<AbstractViewDTO, ViewType>(
                e => e.Model,
                t =>
                {
                    t.AddType<AdminViewDTO>(ViewType.ADMIN);
                    t.AddType<FileViewDTO>(ViewType.FILE);
                    t.AddType<ListViewDTO>(ViewType.LIST);
                    t.AddType<SqlViewDTO>(ViewType.SQL);
                });
        }
    }
}
