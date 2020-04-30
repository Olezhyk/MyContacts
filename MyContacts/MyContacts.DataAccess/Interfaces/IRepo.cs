using System;
using System.Linq;
using MyContacts.Entities.Models;

namespace MyContacts.DataAccess.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        //Task<IEnumerable<TEntity>> GetAsync();

        IQueryable<Contact> Contacts { get; }

        TEntity GetById<T>(Guid? id) where T : class;

        //Task InsertAsync(TEntity item);

        //Task UpdateAsync(TEntity item);

        //Task InsertOrUpdate(TEntity entity);

        //Task DeleteByIdAsync(Guid? id);

        //Task DeleteAsync(TEntity item);
    }
}