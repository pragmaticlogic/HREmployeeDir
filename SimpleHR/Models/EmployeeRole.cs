using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleHR.Models
{
    public class EmployeeRole
    {
        [Key]
        [Column(Order = 1)]
        public string LoginId { get; set; }

        [Key]
        [Column(Order = 2)]
        public _RoleName RoleName { get; set; }

        [ForeignKey("LoginId")]
        public virtual Credential Credential { get; set; }

        [ForeignKey("RoleName")]
        public virtual Role Role { get; set; }
    }
}