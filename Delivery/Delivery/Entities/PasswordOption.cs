using System;
using System.Security.Cryptography;
using System.Text;

namespace Delivery
{
    public class PasswordOption
    {
        public static string Encrypt(string origin)
        {
            return origin;
        }

        public static string Decrypt(string encrypt)
        {
            return encrypt;
        }
    }
}