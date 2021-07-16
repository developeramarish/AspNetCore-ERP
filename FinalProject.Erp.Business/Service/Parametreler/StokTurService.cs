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
    public class StokTurService : IStokTurService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StokTurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<StokTur, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokTur>().Any(filter);
        }

        public int Count(Expression<Func<StokTur, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<StokTur>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<StokTur>().Delete(id);
        }

        public void Delete(StokTur entity)
        {
            _unitOfWork.GetRepository<StokTur>().Delete(entity);
        }

        public void Delete(Expression<Func<StokTur, bool>> filter)
        {
            _unitOfWork.GetRepository<StokTur>().Delete(filter);
        }

        public StokTur Get(Expression<Func<StokTur, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokTur>().Get(filter);
        }

        public IEnumerable<StokTur> GetAll(Expression<Func<StokTur, bool>> filter = null, Func<IQueryable<StokTur>, IOrderedQueryable<StokTur>> orderBy = null)
        {
            return _unitOfWork.GetRepository<StokTur>().GetAll(filter, orderBy);
        }

        public StokTur GetById(int id)
        {
            return _unitOfWork.GetRepository<StokTur>().GetById(id);
        }

        public bool Insert(StokTur entity)
        {
            _unitOfWork.GetRepository<StokTur>().Insert(entity);
            return true;
        }

        public bool Update(StokTur entity)
        {
            _unitOfWork.GetRepository<StokTur>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<StokTur, string>> filter, Expression<Func<StokTur, bool>> where = null)
        {
            return _unitOfWork.GetRepository<StokTur>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<StokTur>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<StokTur> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}