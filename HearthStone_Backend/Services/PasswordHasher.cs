using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HearthStone_Backend.Services
{
    public class PasswordHasher
    {
        public string CreateHashedPassword(string password)
        {
            byte[] salt = new byte[16];
            var RNGService = new RNGCryptoServiceProvider();
            RNGService.GetBytes(salt);

            var Rfc = new Rfc2898DeriveBytes(password, salt);
            byte[] hash = Rfc.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public bool VerifyPasswords(string userEnteredPassword, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(userEnteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);


            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }

            }
            return true;
        }
    }
}
