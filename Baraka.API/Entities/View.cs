namespace Baraka.API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
        [Required]
        public virtual BundleDTO Label { get; set; }

        /// <summary>
        ///     Configuration de la vue.
        /// </summary>
        [Required]
        public virtual AbstractViewConfigurationDTO Configuration { get; set; }
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
            PropertyJsonGeneric<AbstractViewConfigurationDTO, ViewType>(
                e => e.Configuration,
                t =>
                {
                    t.AddType<AdminViewConfigurationDTO>(ViewType.ADMIN);
                    t.AddType<FileViewConfigurationDTO>(ViewType.FILE);
                    t.AddType<ListViewConfigurationDTO>(ViewType.LIST);
                    t.AddType<SqlViewConfigurationDTO>(ViewType.SQL);
                });
        }
    }
}
