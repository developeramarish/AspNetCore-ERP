using FinalProject.Erp.Core.Abstract.Base;
using FinalProject.Erp.Core.Abstract.Repository;
using System;

namespace FinalProject.Erp.Core.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new();
        bool SaveChanges();
    }
}