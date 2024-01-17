using Infrastructure.Cross.Security.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cross.Security.Cryptography
{
    public static class CryptographyHelper
    {
        #region Rijndael

        #region Fábrica

        /// <summary>
        /// Crea una instancia del algoritmo de encripción simétrica Rijndael.
        /// </summary>
        /// <param name="password">Contraseña.</param>
        /// <returns>Una instancia del algoritmo de encripción simétrica Rijndael.</returns>
        private static Rijndael CreateRijndael(string password)
        {
            Rijndael rijndael = Rijndael.Create();

            // Convierte la contraseña en un byte array.
            PasswordDeriveBytes secretKey =
              new PasswordDeriveBytes(
                password,
                Encoding.ASCII.GetBytes(password.Length.ToString()));

            // El Key array de la clase Rijndeal tiene una longitud de 32 bytes, en forma predeterminada.
            rijndael.Key = secretKey.GetBytes(32);
            // El Initialization Vector array de la clase Rijndeal tiene una longitud de 16 bytes, en forma predeterminada.
            rijndael.IV = secretKey.GetBytes(16);

            return rijndael;
        }

        /// <summary>
        /// Crea una instancia del CryptoStream para encriptar.
        /// </summary>
        /// <param name="rijndael">Instancia del algoritmo de encripción simétrica Rijndael.</param>
        /// <returns>Una instancia del CryptoStream para encriptar.</returns>
        private static CryptoStream CreateStreamForEncryption(Rijndael rijndael)
        {
            ICryptoTransform transform = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
            return new CryptoStream(new MemoryStream(), transform, CryptoStreamMode.Write);
        }

        /// <summary>
        /// Crea una instancia del CryptoStream para desencriptar.
        /// </summary>
        /// <param name="rijndael">Instancia del algoritmo de encripción simétrica Rijndael.</param>
        /// <param name="data">Datos para inicializar el CryptoStream.</param>
        /// <returns>Una instancia del CryptoStream para desencriptar.</returns>
        private static CryptoStream CreateStreamForDecryption(Rijndael rijndael, byte[] data)
        {
            ICryptoTransform transform = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);
            return new CryptoStream(new MemoryStream(data), transform, CryptoStreamMode.Read);
        }

        #endregion

        #region Encriptación

        /// <summary>
        /// Devuelve el texto encriptado, utilizando la contraseña especificada.
        /// </summary>
        /// <param name="text">Texto a encriptar.</param>
        /// <param name="password">Contraseña.</param>
        /// <returns>El texto encriptado, utilizando la contraseña especificada.</returns>
        public static string RijndaelEncrypt(string text, string password)
        {
            // Crea una instancia del algoritmo de encripción simétrica Rijndael y el CryptoStream.
            Rijndael rijndael = CryptographyHelper.CreateRijndael(password);
            // Obtiene el byte array del texto a encriptar.
            byte[] encriptedData = Encoding.UTF8.GetBytes(text);
            CryptoStream cs = CryptographyHelper.CreateStreamForEncryption(rijndael);

            // Encripta byte array y escribe el resultado en el MemoryStream.
            cs.Write(encriptedData, 0, encriptedData.Length);
            cs.FlushFinalBlock();

            // Recupera el byte array del MemoryStream.
            encriptedData = ((MemoryStream)ReflectionHelper.GetInstanceFieldValue(cs, "_stream")).ToArray();
            cs.Close();

            // Devuelve el byte array convertidos en un string de 64 bytes.
            return Convert.ToBase64String(encriptedData);
        }

        private const string _alg = "HmacSHA256";
        private const string _salt = "rz8PeQlMJFphj9WQfvFh";

        public static string EncryptSHA256(string hash, string password)
        {
            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                hash = Convert.ToBase64String(hmac.Hash);
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(hash));
        }

        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }

        #endregion

        #region Desencriptación

        /// <summary>
        /// Devuelve el texto desencriptado, utilizando la contraseña especificada.
        /// </summary>
        /// <param name="text">Texto a desencriptar.</param>
        /// <param name="password">Contraseña.</param>
        /// <returns>El texto desencriptado, utilizando la contraseña especificada.</returns>
        public static string RijndaelDecrypt(string text, string password)
        {
            // Crea una instancia del algoritmo de encripción simétrica Rijndael y el CryptoStream.
            Rijndael rijndael = CryptographyHelper.CreateRijndael(password);
            // Obtiene el byte array del texto encriptado.
            byte[] encryptedData = Convert.FromBase64String(text);
            CryptoStream cs = CryptographyHelper.CreateStreamForDecryption(rijndael, encryptedData);

            // Obtiene el byte array del texto a desencriptar.
            byte[] decryptedData = new byte[encryptedData.Length];
            // Desencripta byte array y escribe el resultado en el MemoryStream.
            cs.Read(decryptedData, 0, decryptedData.Length);
            cs.Close();

            // Devuelve el byte array convertidos en un string de 64 bytes.
            return Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length).TrimEnd('\0');
        }

        #endregion

        #endregion

        #region MD5

        public static string GetMD5(string text)
        {
            MD5 csp = MD5CryptoServiceProvider.Create();
            byte[] hashedData = csp.ComputeHash(Encoding.Default.GetBytes(text));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashedData.Length; i++)
                sb.Append(string.Format("{0:x2}", hashedData[i]));

            return sb.ToString();
        }

        #endregion MD5
    }
}
