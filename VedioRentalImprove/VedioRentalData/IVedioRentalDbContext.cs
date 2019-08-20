using VedioRentalModels;
using VideoRental.Models;

namespace VedioRentalData
{
    public interface IVedioRentalDbContext
    {
        System.Data.Entity.IDbSet<Customer> Customers { get; set; }
        System.Data.Entity.IDbSet<Genre> Genres { get; set; }
        System.Data.Entity.IDbSet<MembershipType> MembershipTypes { get; set; }
        System.Data.Entity.IDbSet<Movie> Movies { get; set; }

        int SaveChanges();
    }
}