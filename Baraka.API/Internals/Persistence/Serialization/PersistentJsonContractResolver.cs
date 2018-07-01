namespace Baraka.API.Internals.Persistence.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     Gestionnaire de contrats applicables aux DTO stockés en JSON.
    /// </summary>
    public class PersistentJsonContractResolver : DefaultContractResolver
    {
        /// <summary>
        ///     Constructeur.
        /// </summary>
        public PersistentJsonContractResolver()
        {
        }
    }
}
