using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ProjectDetails
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}