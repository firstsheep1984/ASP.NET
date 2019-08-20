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
    public class VedioRentalData : IVedioRentalData
    {
        private IVedioRentalDbContext context;
        private IDictionary<Type, object> repositories;
        public VedioRentalData(IVedioRentalDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users { get { return GetRepository<User>(); } }
        public IRepository<Customer> Customers { get { return GetRepository<Customer>(); } }
        public IRepository<MembershipType> MembershipTypes { get { return GetRepository<MembershipType>(); } }
        public IRepository<Movie> Movies { get { return GetRepository<Movie>(); } }
        public IRepository<Genre> Genres { get { return GetRepository<Genre>(); } }

        private IRepository<T> GetRepository<T>() where T: class
        {
            var type = typeof(T);
            if (!repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                repositories.Add(type, repository);
            }
            return (IRepository<T>)repositories[type];
        }
        
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
