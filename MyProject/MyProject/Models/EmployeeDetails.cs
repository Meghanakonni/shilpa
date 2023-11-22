using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmpID { get; set; }
        public string Employeename { get; set; }
        public string Grade { get; set; }
        public string Designation { get; set; }
    }
}