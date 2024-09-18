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

        public DbSet<StudentsDetails> StudentsDetails { get; set; }


        public MyDb() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Students>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<StudentsDetails>()
                .HasKey(sd => sd.ID);


            modelBuilder.Entity<StudentsDetails>()
                .HasIndex(s => s.StudentID)
                .IsUnique();

            // Configure the one-to-one relationship between Students and StudentsDetails
            // can??? substitute this with [Required] [ForeignKey("Student")]
            modelBuilder.Entity<Students>()
                .HasOptional(s => s.Details)  // A Student may have a Details entity
                .WithRequired(sd => sd.Student);  // StudentsDetails must have a Student, but Student is not required to have Details
                



            base.OnModelCreating(modelBuilder);

        }

        public System.Data.Entity.DbSet<MVC_Code_first_17_9.Models.Courses> Courses { get; set; }
    }
}