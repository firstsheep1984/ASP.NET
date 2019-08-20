using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VedioRentalData.Repositories;
using VedioRentalModels;
using VideoRental.Models;

namespace VedioRentalData
{
    public interface IVedioRentalData
    {
        IRepository<User> Users { get;  }
        IRepository<Customer> Customers { get; }
        IRepository<Movie> Movies { get; }
        IRepository<MembershipType> MembershipTypes { get; }
        IRepository<Genre> Genres { get; }

        int SaveChanges();

    }
}
