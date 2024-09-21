namespace MVC_Code_first_19_9.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_Code_first_19_9.Models.MyDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_Code_first_19_9.Models.MyDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Users.AddOrUpdate(
                new Models.Users { Name = "Nahid", Email = "nahid@gamil.com", Password = "123", Role = "Principal" },
                new Models.Users { Name = "Lamees", Email = "lamees@gamil.com", Password = "123", Role = "Teacher" },
                new Models.Users { Name = "Eman", Email = "eman@gmail.com", Password = "123", Role = "Teacher" }
                );


            context.Subjects.AddOrUpdate(
                new Models.Subjects { Name = "Math"},
                new Models.Subjects { Name = "English"},
                new Models.Subjects { Name = "Computer Scince"},
                new Models.Subjects { Name = "PE"},
                new Models.Subjects { Name = "Scince"}
                );




            context.SaveChanges();

        }
    }
}
