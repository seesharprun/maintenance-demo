using System;
using System.Security.Cryptography;
using System.Text;

namespace Maintenance.Web.Models
{
    public static class Authentication
    {
        private const string SALT = "VTHXZEKJVKHOFWTMFPYWHYHY";

        public static string GeneratePasswordHash(string password)
        {
            var passwordByteArray = Encoding.UTF8.GetBytes(password);
            var saltByteArray = Encoding.UTF8.GetBytes(SALT);
            var resultByteArray = GenerateSaltedHash(passwordByteArray, saltByteArray);
            return Convert.ToBase64String(resultByteArray);
        }

        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
