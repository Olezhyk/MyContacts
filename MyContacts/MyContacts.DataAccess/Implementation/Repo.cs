using System;
using System.Data.Entity;
using System.Threading.Tasks;
using MyContacts.DataAccess.Context;

namespace MyContacts.DataAccess.Implementation
{
    public class Repo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        protected MyContactsContext context;

        public Repo(MyContactsContext context)
        {
            this.context = context;
        }

        //public Task DeleteAsync(TEntity item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteByIdAsync(Guid? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<System.Collections.Generic.IEnumerable<TEntity>> GetAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<TEntity> GetByIdAsync<T>(Guid? id) where T : class
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        //public Task InsertAsync(TEntity item)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task InsertOrUpdate(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task UpdateAsync(TEntity item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}