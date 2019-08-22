namespace HomeInventory.Migrations
{
    using System.Data.Entity.Migrations;
    using HomeInventory.Infraestructure;
    using HomeInventory.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeInventory.Infraestructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(ApplicationDbContext context)
        {
            context.Locations.AddOrUpdate(l => l.Name,
                new Location()
                {
                    Name = "Home Office"
                },
                new Location()
                {
                    Name = "Family Room"
                },
                new Location()
                {
                    Name = "Living Room"
                },
                new Location()
                {
                    Name = "Kitchen"
                },
                new Location()
                {
                    Name = "Master Bedroom"
                },
                new Location()
                {
                    Name = "Bedroom Two"
                },
                new Location()
                {
                    Name = "Bedroom Three"
                },
                new Location()
                {
                    Name = "Bathrooms"
                },
                new Location()
                {
                    Name = "Garage"
                },
                new Location()
                {
                    Name = "Attic"
                },
                new Location()
                {
                    Name = "Basement"
                },
                new Location()
                {
                    Name = "Other"
                }
           );
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
