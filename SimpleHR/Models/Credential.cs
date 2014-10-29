using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleHR.Models
{
    public class Credential
    {        
        [Key]
        public string LoginId { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<EmployeeRole> EmployeeRoles; 
    }
}