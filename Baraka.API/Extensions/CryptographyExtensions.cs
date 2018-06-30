namespace Baraka.API.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    ///     Extensions de cryptographie.
    /// </summary>
    internal static class CryptographyExtensions
    {
        /// <summary>
        ///     Convertit une chaîne de caractères UTF-8 via SHA256.
        /// </summary>
        /// <param name="data">Chaîne d'entrée.</param>
        /// <returns>Chaîne de sortie.</returns>
        internal static string ToSHA256(this string data)
        {
            byte[] input = Encoding.UTF8.GetBytes(data);
            using (SHA256 shaM = new SHA256Managed())
            {
                byte[] output = shaM.ComputeHash(input);
                return Encoding.UTF8.GetString(output);
            }
        }
    }
}
