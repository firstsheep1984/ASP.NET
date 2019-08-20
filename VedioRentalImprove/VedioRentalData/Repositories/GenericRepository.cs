using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VedioRentalData.Repositories
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IDbSet<T> Set
        {
            get { return set; }
        }
        public void Add(T entity)
        {
            ChangeState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Delete(T entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public T Delete(object id)
        {
            var entity = Find(id);
            Delete(entity);
            return entity;
            
        }

        public T Find(object id)
        {
            return set.Find(id);
        }

        public void Update(T entity)
        {
            ChangeState(entity, EntityState.Modified);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if(entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }
            entry.State = state;

        }
    }
}
