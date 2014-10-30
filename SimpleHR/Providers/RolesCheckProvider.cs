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
    public class RolesCheckProvider : IRolesCheckProvider
    {
        private EmployeeDbContext db = new EmployeeDbContext();

        public bool IsEmployeeInHR(string loginId)
        {
            var employeeRoles = db.EmployeeRoles.Where(p => p.LoginId == loginId && p.RoleName == _RoleName.HR).ToList<EmployeeRole>();
            return employeeRoles.Count() > 0 ? true : false;
        }
    }
}