using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class RegisterContext : DbContext
    {
        public RegisterContext() : base("name=connectstr")
        { }
        public DbSet<Register> Registration { get; set; }
    }
}