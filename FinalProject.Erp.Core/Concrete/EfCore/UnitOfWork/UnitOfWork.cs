using FinalProject.Erp.Core.Abstract.Base;
using FinalProject.Erp.Core.Abstract.Repository;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Core.Concrete.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace FinalProject.Erp.Core.Concrete.EfCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new()
        {
            return new EfGenericRepository<TEntity>(_context);
        }

        public bool SaveChanges()
        {
            using TransactionScope tScope = new TransactionScope();
            _context.SaveChanges();
            tScope.Complete();
            return true;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
