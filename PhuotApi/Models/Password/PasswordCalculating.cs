using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using PasswordSecurity;
namespace PhuotApi.Models
{
    public class PasswordCalculating
    {
        public static byte[] GeneratedSaltPassword()
        {
            //24b
            var data = new byte[PasswordStorage.SALT_BYTES];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetBytes(data);

            return data;
        }

        //algorithm:iterations:hashSize:salt:hash
        public static string EncryptPassword(string password, byte[] salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt))
            {
                pbkdf2.IterationCount = PasswordStorage.PBKDF2_ITERATIONS; //64000
                var b = pbkdf2.GetBytes(PasswordStorage.HASH_BYTES); //18b
                return Convert.ToBase64String(b);
            }
        }
    }
}