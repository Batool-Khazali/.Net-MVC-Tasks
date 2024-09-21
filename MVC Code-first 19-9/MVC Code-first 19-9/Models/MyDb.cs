using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVC_Code_first_19_9.Models;

namespace MVC_Code_first_19_9.Models
{
    public class MyDb : DbContext
    {

        public DbSet<Users> Users { get; set; }

        public DbSet<Subjects> Subjects { get; set; }

        public DbSet<Classes> Classes { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<Tasks> Tasks { get; set; }




        public MyDb() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}