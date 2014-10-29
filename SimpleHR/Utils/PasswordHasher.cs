using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SimpleHR.Utils
{
    public class PasswordHasher
    {
        public string HashPassword(string clearText)
        {
            using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
            {
                byte[] dataToHash = Encoding.UTF8.GetBytes(clearText);
                byte[] hashed = sha.ComputeHash(dataToHash);
                return Convert.ToBase64String(hashed);
            }
        }
    }
}