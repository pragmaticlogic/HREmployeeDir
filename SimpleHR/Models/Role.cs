using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleHR.Models
{
    public enum _RoleName
    {
        Employee,
        HR,
        Admin
    }

    public class Role
    {        
        [Key]
        public _RoleName RoleName { get; set; }

        public ICollection<EmployeeRole> EmployeeRoles;
    }
}