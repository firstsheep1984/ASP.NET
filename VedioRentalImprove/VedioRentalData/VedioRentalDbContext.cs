using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VedioRentalModels;
using VedioRentalData;
using VideoRental.Models;

namespace VedioRentalData
{
    public class VedioRentalDbContext : IdentityDbContext<User>, IVedioRentalDbContext
    {
        public VedioRentalDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static VedioRentalDbContext Create()
        {
            return new VedioRentalDbContext();
        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Movie> Movies { get; set; }
        public IDbSet<MembershipType> MembershipTypes { get; set; }
        public IDbSet<Genre> Genres { get; set; }
    }
}
