using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MyContacts.DataAccess.Context;
using MyContacts.DataAccess.Interfaces;
using MyContacts.Entities.Models;

namespace MyContacts.DataAccess.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContactsContext context;
        
        private DbSet<TEntity> Set { get; }

        public Repository(MyContactsContext context)
        {
            Set = context.Set<TEntity>();
            this.context = context;
        }

        public IQueryable<TEntity> Get<T>()
        {
            return Set;
        }

        public TEntity GetById<T>(Guid? id) where T : class
        {
            return Set.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Set.Add(entity);
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete<T>(Guid? id) where T : class
        {
            var entity = Set.Find(id);
            if (entity != null)
                Set.Remove(entity);

            SaveChanges();
        }

        public void Delete(TEntity item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                Set.Attach(item);
            }

            Set.Remove(item);
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}