using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Code_first_17_9.Models;
using System.Data.Entity;


namespace MVC_Code_first_17_9.Models
{
    public class MyDb : DbContext
    {

        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Assignments> Assignments { get; set; }


        public MyDb() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}