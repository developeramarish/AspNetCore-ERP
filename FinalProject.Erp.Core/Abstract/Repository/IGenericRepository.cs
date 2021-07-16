using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Core.Abstract.Repository
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        void RecordHide(int id, bool hide);

        void Delete(int id);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(int id);

        TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        bool Any(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          params Expression<Func<TEntity, object>>[] includes
        );

        int Count(Expression<Func<TEntity, bool>> filter = null);

        string NewCode(KartTuru kartTuru, Expression<Func<TEntity, string>> filter, Expression<Func<TEntity, bool>> where = null);
    }
}