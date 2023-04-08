using System;
using System.Security.Cryptography;
using System.Text;

namespace GiaoHang
{
    public class PasswordOption
    {
        private static readonly byte[] key = { 2, 3, 0, 2 };
        public static string Encrypt(string origin)
        {
            if (origin == null) throw new ArgumentNullException("origin");
            //encrypt data
            var data = Encoding.Unicode.GetBytes(origin);
            byte[] encrypted = ProtectedData.Protect(data, key, DataProtectionScope.CurrentUser);

            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string encrypt)
        {
            if (encrypt == null) throw new ArgumentNullException("encrypt");

            //parse base64 string
            byte[] data = Convert.FromBase64String(encrypt);

            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, key, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }
    }
}