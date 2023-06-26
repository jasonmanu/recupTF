using System;
using System.Security.Cryptography;
using System.Text;

namespace FormSupport
{
    public static class CryptoHelper
    {
        public static string Hash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashedBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
