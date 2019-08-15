namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {
            context.Students.AddOrUpdate(s => s.StudentId,
                new Models.Student() { StudentId = 1, Name = "Robert", Age = 24, EnrollmentDate = new DateTime(2009,1,1) },
                new Models.Student() { StudentId = 2, Name = "Mike", Age = 25, EnrollmentDate = new DateTime(2010, 1, 1) },
                new Models.Student() { StudentId = 3, Name = "Theresa", Age = 23, EnrollmentDate = new DateTime(2009, 2, 1) });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
