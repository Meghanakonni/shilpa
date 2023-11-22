using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=connectstr")
        { }
        public DbSet<EmployeeLogin> EmpLogin { get; set; }

        public DbSet<ManagerLogin> MngLogin { get; set; }

    }
}