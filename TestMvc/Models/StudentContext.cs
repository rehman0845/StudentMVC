using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestMvc.Models
{
    public class StudentContext : DbContext 
    {
        public StudentContext()
            : base("name=sqlconnection")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Batch> Batches { get; set; }
    }
}