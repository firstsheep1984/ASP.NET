using HomeInventory.Migrations;
using HomeInventory.Models;
using HomeInventory.ViewModels;
using System.Data.Entity;

namespace HomeInventory.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<HomeItem> HomeItems { get; set; }
        public IDbSet<PurchaseInfo> PurchaseInfoes { get; set; }
        public IDbSet<Location> Locations { get; set; }
    }
}