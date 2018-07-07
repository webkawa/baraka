namespace Baraka.API.Internals.Logging
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NLog;
    using NLog.LayoutRenderers;

    /// <summary>
    ///     Formateur de logs.
    /// </summary>
    public class CustomLayoutRenderer : LayoutRenderer
    {
        /// <summary>
        ///     <see cref="CustomLayoutRenderer.Append(StringBuilder, LogEventInfo)" />
        /// </summary>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            // Ligne de base
            builder.AppendFormat(
                "{0} - At {1} : {4}\n", 
                logEvent.Level,
                DateTime.Now,
                logEvent.CallerClassName,
                logEvent.CallerLineNumber,
                logEvent.Message);

            // Gestion des erreurs
            if (logEvent.Exception != null)
            {
                builder.AppendFormat(
                    "{0}\n",
                    logEvent.Exception.Message);
                builder.Append(logEvent.Exception.StackTrace);
                builder.Append("\n\n");
            }
        }
    }
}
