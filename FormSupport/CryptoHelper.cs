using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FormSupport
{
    public static class CryptoHelper
    {
        public static string Hash(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            data = new SHA256Managed().ComputeHash(data);
            string hash = Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
