namespace Baraka.API.Internals.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NHibernate.Cfg;
    using NHibernate.Util;

    /// <summary>
    ///     Stratégie de nommage NHibernate.
    /// </summary>
    public class NamingStrategy : INamingStrategy
    {
        /// <summary>
        ///     Liste des mots-clefs protégés.
        /// </summary>
        private static string[] ESCAPES = new string[]
        {
            "table",
            "user"
        };

        /// <summary>
        ///     Retourne le nom de la table SQL rattachée à une classe.
        /// </summary>
        /// <param name="className">Nom de la classe.</param>
        /// <returns>Nom de la table.</returns>
        public string ClassToTableName(string className)
        {
            return StringToSQL(StringHelper.Unqualify(className));
        }

        /// <summary>
        ///     Retourne le nom d'une colonne SQL rattachable à une propriété.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété.</param>
        /// <returns>Nom de la colonne.</returns>
        public string PropertyToColumnName(string propertyName)
        {
            return StringToSQL(StringHelper.Unqualify(propertyName));
        }

        /// <summary>
        ///     Procède au retraitement d'un nom de table.
        /// </summary>
        /// <param name="tableName">Nom de la table.</param>
        /// <returns>Nom traité.</returns>
        public string TableName(string tableName)
        {
            return StringToSQL(tableName);
        }

        /// <summary>
        ///     Procède au retraitement d'un nom de colonne.
        /// </summary>
        /// <param name="columnName">Nom à traiter.</param>
        /// <returns>Nom traité.</returns>
        public string ColumnName(string columnName)
        {
            return StringToSQL(columnName);
        }

        /// <summary>
        ///     Retourne le nom de table rattachable à une propriété.
        /// </summary>
        /// <param name="className">Nom de la classe.</param>
        /// <param name="propertyName">Nom de la propriété.</param>
        /// <returns>Nom qualifié.</returns>
        public string PropertyToTableName(string className, string propertyName)
        {
            return StringToSQL(StringHelper.Unqualify(propertyName));
        }

        /// <summary>
        ///     Retourne le nom d'une colonne logique.
        /// </summary>
        /// <param name="columnName">Nom de la colonne.</param>
        /// <param name="propertyName">Nom de la propriété.</param>
        /// <returns>Nom qualifié.</returns>
        public string LogicalColumnName(string columnName, string propertyName)
        {
            return StringHelper.IsNotEmpty(columnName) ?
                StringToSQL(columnName) :
                StringToSQL(StringHelper.Unqualify(propertyName));
        }

        /// <summary>
        ///     Procède à la conversion d'une chaîne de caractères, probablement au format "UpperCamelCase", 
        ///     à une notation compatible SQL.
        ///     Par exemple : "SomeUserTable" à "some_user_table".
        /// </summary>
        /// <param name="value">Valeur à traiter.</param>
        /// <returns>Valeur traitée.</returns>
        private string StringToSQL(string value)
        {
            // Traitement
            bool first = true;
            bool upper = false;
            var split = value
                .Select((letter) =>
                {
                    if (char.IsUpper(letter) && !first)
                    {
                        if (upper)
                        {
                            return char.ToLowerInvariant(letter).ToString();
                        }
                        else
                        {
                            upper = true;
                            return string.Concat(
                                "_",
                                char.ToLowerInvariant(letter));
                        }
                    }

                    first = false;
                    upper = false;
                    return char.ToLowerInvariant(letter).ToString();
                })
                .ToArray();
            
            // Concaténation
            string result = string.Concat(split);
            if (ESCAPES.Contains(result))
            {
                result = string.Format("[{0}]", result);
            }

            // Renvoi
            return result;
        }
    }
}
