using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Entities.Parametreler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Service.Parametreler
{
    public class UlkeService : IUlkeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UlkeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Ulke, bool>> filter)
        {
            return _unitOfWork.GetRepository<Ulke>().Any(filter);
        }

        public int Count(Expression<Func<Ulke, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Ulke>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Ulke>().Delete(id);
        }

        public void Delete(Ulke entity)
        {
            _unitOfWork.GetRepository<Ulke>().Delete(entity);
        }

        public void Delete(Expression<Func<Ulke, bool>> filter)
        {
            _unitOfWork.GetRepository<Ulke>().Delete(filter);
        }

        public Ulke Get(Expression<Func<Ulke, bool>> filter)
        {
            return _unitOfWork.GetRepository<Ulke>().Get(filter);
        }

        public IEnumerable<Ulke> GetAll(Expression<Func<Ulke, bool>> filter = null, Func<IQueryable<Ulke>, IOrderedQueryable<Ulke>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Ulke>().GetAll(filter, orderBy);
        }

        public Ulke GetById(int id)
        {
            return _unitOfWork.GetRepository<Ulke>().GetById(id);
        }

        public bool Insert(Ulke entity)
        {
            _unitOfWork.GetRepository<Ulke>().Insert(entity);
            return true;
        }

        public bool Update(Ulke entity)
        {
            _unitOfWork.GetRepository<Ulke>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Ulke, string>> filter, Expression<Func<Ulke, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Ulke>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Ulke>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<Ulke> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}