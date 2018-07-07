namespace Baraka.API.Internals.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Baraka.API.DTO.Persisted.Shared;

    /// <summary>
    ///     Identifiants de lots
    /// </summary>
    public enum BundleId
    {
        /// <summary>
        ///     Texte de test.
        /// </summary>
        LOREM_IPSUM,

        /// <summary>
        ///     Session expirée.
        /// </summary>
        ERROR_EXPIRED_SESSION,
        
        /// <summary>
        ///     Identifiants invalides.
        /// </summary>
        ERROR_INVALID_CREDENTIALS,

        /// <summary>
        ///     Jeton invalide.
        /// </summary>
        ERROR_INVALID_TOKEN,

        /// <summary>
        ///     Erreur inconnue.
        /// </summary>
        ERROR_UNKNOW,

        /// <summary>
        ///     Erreur d'authentification.
        /// </summary>
        ERROR_UNKNOW_AUTHENTICATION,

        /// <summary>
        ///     Erreur interne.
        /// </summary>
        ERROR_UNKNOW_INTERNAL,

        /// <summary>
        ///     Requête non-sécurisée.
        /// </summary>
        ERROR_UNSECURED_REQUEST
    }
}
