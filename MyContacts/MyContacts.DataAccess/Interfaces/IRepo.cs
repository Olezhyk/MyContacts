using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyContacts.DataAccess
{
    public interface IRepo<TEntity> where TEntity : class
    {
        //Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetByIdAsync<T>(Guid? id) where T : class;

        //Task InsertAsync(TEntity item);

        //Task UpdateAsync(TEntity item);

        //Task InsertOrUpdate(TEntity entity);

        //Task DeleteByIdAsync(Guid? id);

        //Task DeleteAsync(TEntity item);
    }
}