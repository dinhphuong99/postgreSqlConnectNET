using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_EF_CRUD_Postgresql.Models
{
    [Table(name:"emp", Schema ="public")]
    public class EmpClass
    {
        [Key]
        public int empId { get; set; }
        public string empName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
    }
}