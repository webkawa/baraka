namespace Baraka.API.Internals.Engine.Contracts.Instructions.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///     Requête.
    ///     Objet représentatif d'une requête SQL (lecture ou écriture) en attente
    ///     d'exécution dans la base de données.
    /// </summary>
    internal interface IQuery
    {
    }

    /// <summary>
    ///     Requête.
    /// </summary>
    internal class AbstractQuery : IQuery
    {
    }
}
