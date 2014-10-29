using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleHR.Models
{
    public class Employee
    {        
        public string FirstName { get; set; }        
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string OfficePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
      
        [Key]        
        public Guid EmployeeId { get; set; }

        public string LoginId { get; set; }

        [ForeignKey("LoginId")]
        public Credential Credential { get; set; }
    }
}