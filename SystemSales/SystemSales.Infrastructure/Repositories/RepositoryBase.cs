using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystemSales.Domain.Contracts.Repositories;

namespace SystemSales.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected SalesContext Db = new SalesContext();

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
            Db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Db.Set<TEntity>().Find(id);
            Db.Set<TEntity>().Remove(entity);
            Db.SaveChanges();
        }

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Db.Dispose();
            }
            _disposed = true;
        }

        ~RepositoryBase()
        {
                Dispose(false);
        }
    }
}
