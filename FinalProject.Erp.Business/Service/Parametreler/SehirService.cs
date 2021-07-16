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
    public class SehirService : ISehirService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SehirService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Sehir, bool>> filter)
        {
            return _unitOfWork.GetRepository<Sehir>().Any(filter);
        }

        public int Count(Expression<Func<Sehir, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Sehir>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Sehir>().Delete(id);
        }

        public void Delete(Sehir entity)
        {
            _unitOfWork.GetRepository<Sehir>().Delete(entity);
        }

        public void Delete(Expression<Func<Sehir, bool>> filter)
        {
            _unitOfWork.GetRepository<Sehir>().Delete(filter);
        }

        public Sehir Get(Expression<Func<Sehir, bool>> filter)
        {
            return _unitOfWork.GetRepository<Sehir>().Get(filter);
        }

        public IEnumerable<Sehir> GetAll(Expression<Func<Sehir, bool>> filter = null, Func<IQueryable<Sehir>, IOrderedQueryable<Sehir>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Sehir>().GetAll(filter, orderBy);
        }

        public Sehir GetById(int id)
        {
            return _unitOfWork.GetRepository<Sehir>().GetById(id);
        }

        public bool Insert(Sehir entity)
        {
            _unitOfWork.GetRepository<Sehir>().Insert(entity);
            return true;
        }

        public bool Update(Sehir entity)
        {
            _unitOfWork.GetRepository<Sehir>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Sehir, string>> filter, Expression<Func<Sehir, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Sehir>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Sehir>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<Sehir> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}