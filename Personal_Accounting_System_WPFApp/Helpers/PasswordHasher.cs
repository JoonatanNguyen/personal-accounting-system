using System;
using System.Security.Cryptography;

namespace Personal_Accounting_System_WPFApp.Helpers
{
    class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool CompareHash(string password, string _hash)
        {
            byte[] hashBytes = Convert.FromBase64String(_hash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbdkf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbdkf2.GetBytes(20);

            int ok = 1;
            for (var i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    ok = 0;
                }
            }
            if (ok == 1)
            {
                return true;
            }
            return false;
        }
    }
}
