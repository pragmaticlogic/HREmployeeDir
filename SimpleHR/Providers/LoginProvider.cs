using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleHR.DataAccess;
using SimpleHR.Models;
using SimpleHR.Utils;

namespace SimpleHR.Providers
{
    public class LoginProvider : ILoginProvider
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        public bool ValidateUser(string loginId, string password)
        {
            var hasher = new PasswordHasher();
            Credential credential = db.Credentials.Find(loginId);

            return credential != null && credential.PasswordHash == hasher.HashPassword(password);               
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }            
        }
    }
}