using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Common.Extensions;
using FinalProject.Erp.Common.Tools;
using FinalProject.Erp.Core.Abstract.Base;
using FinalProject.Erp.Core.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FinalProject.Erp.Core.Concrete.EfCore.Repository
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().AsNoTracking().Any(filter);
        }

        public void RecordHide(int id, bool hide)
        {
            TEntity entityToDelete = _dbSet.Find(id);

            PropertyInfo propertyInfo = entityToDelete.GetType().GetProperty("Silindi");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entityToDelete, hide, null);
            }

            if (hide)
            {
                propertyInfo = entityToDelete.GetType().GetProperty("SilinmeTarih");
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entityToDelete, DateTime.Now, null);
                }

                propertyInfo = entityToDelete.GetType().GetProperty("SilenId");
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entityToDelete, ErpVariables.AktifPersonelId, null);
                }
            }
            else
            {
                propertyInfo = entityToDelete.GetType().GetProperty("GeriAlmaTarih");
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entityToDelete, DateTime.Now, null);
                }

                propertyInfo = entityToDelete.GetType().GetProperty("GeriAlanId");
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(entityToDelete, ErpVariables.AktifPersonelId, null);
                }
            }

            Update(entityToDelete);
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>().Where(filter));
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            return _context.Set<TEntity>().MyInclude(includes).SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = query.MyInclude(includes);

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Insert(TEntity entity)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("EklemeTarih");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, DateTime.Now, null);
            }

            propertyInfo = entity.GetType().GetProperty("EkleyenId");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, ErpVariables.AktifPersonelId, null);
            }

            _dbSet.Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            PropertyInfo propertyInfo = entity.GetType().GetProperty("DuzenlemeTarih");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, DateTime.Now, null);
            }

            propertyInfo = entity.GetType().GetProperty("DuzenleyenId");
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(entity, ErpVariables.AktifPersonelId, null);
            }

            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbSet.Count() : _dbSet.Count(filter);
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<TEntity, string>> filter, Expression<Func<TEntity, bool>> where = null)
        {
            string Kod()
            {
                string kod = null;
                var kodDizi = kartTuru.ToName().Split(' ');
                for (int i = 0; i < kodDizi.Length - 1; i++)
                {
                    kod += kodDizi[i];
                    if (i + 1 < kodDizi.Length - 1)
                        kod += " ";
                }
                return kod + "-0001";
            }

            string YeniKodVer(string kod)
            {
                var sayisalDegerler = "";
                foreach (var karakter in kod)
                {
                    if (char.IsDigit(karakter))
                        sayisalDegerler += karakter;
                    else
                        sayisalDegerler = "";
                }

                var artisSonraiDeger = (int.Parse(sayisalDegerler) + 1).ToString();
                var fark = kod.Length - artisSonraiDeger.Length;
                if (fark <= 0) fark = 0;

                var yeniDeger = kod.Substring(0, fark);
                yeniDeger += artisSonraiDeger;

                return yeniDeger;
            }

            var maxKod = where == null ? _dbSet.Max(filter) : _dbSet.Where(where).Max(filter);
            return maxKod == null ? Kod() : YeniKodVer(maxKod);
        }
    }
}