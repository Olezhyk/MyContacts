using System;
using System.Linq;
using MyContacts.Entities.Models;

namespace MyContacts.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get<T>();

        TEntity GetById<T>(Guid? id) where T : class;

        void Insert(TEntity entity);

        void Update(TEntity item);

        void Delete<T>(Guid? id) where T : class;

        void Delete(TEntity item);

        void SaveChanges();
    }
}