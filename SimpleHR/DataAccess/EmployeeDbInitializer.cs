using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleHR.Models;
using SimpleHR.Utils;

namespace SimpleHR.DataAccess
{
    public class EmployeeDbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var roles = new List<Role>
            {
                new Role { RoleName = _RoleName.HR },
                new Role { RoleName = _RoleName.Employee },
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var PasswordHasher = new PasswordHasher();

            var credentials = new List<Credential>
            {
                new Credential { LoginId = "kevin", PasswordHash = PasswordHasher.HashPassword("password") },
            };
            credentials.ForEach(c => context.Credentials.Add(c));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { FirstName = "Kevin", MiddleName = "H", Lastname = "Le",
                    Address = "16 Washington St", City = "Houston", County = "Harris",
                    State = "TX", ZipCode = "55555", OfficePhone = "111-222-3333", CellPhone = "444-555-6666",
                    Email = "pragmaticobjects@gmail.com", LoginId = "kevin"},

            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var employeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole { LoginId = "kevin", RoleName = _RoleName.HR },
                new EmployeeRole { LoginId = "kevin", RoleName = _RoleName.Employee },
            };

            employeeRoles.ForEach(er => context.EmployeeRoles.Add(er));
            context.SaveChanges();
        }
    }
}