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
    public class MarkaService : IMarkaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarkaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Marka, bool>> filter)
        {
            return _unitOfWork.GetRepository<Marka>().Any(filter);
        }

        public int Count(Expression<Func<Marka, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Marka>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Marka>().Delete(id);
        }

        public void Delete(Marka entity)
        {
            _unitOfWork.GetRepository<Marka>().Delete(entity);
        }

        public void Delete(Expression<Func<Marka, bool>> filter)
        {
            _unitOfWork.GetRepository<Marka>().Delete(filter);
        }

        public Marka Get(Expression<Func<Marka, bool>> filter)
        {
            return _unitOfWork.GetRepository<Marka>().Get(filter);
        }

        public IEnumerable<Marka> GetAll(Expression<Func<Marka, bool>> filter = null, Func<IQueryable<Marka>, IOrderedQueryable<Marka>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Marka>().GetAll(filter, orderBy);
        }

        public Marka GetById(int id)
        {
            return _unitOfWork.GetRepository<Marka>().GetById(id);
        }

        public bool Insert(Marka entity)
        {
            _unitOfWork.GetRepository<Marka>().Insert(entity);
            return true;
        }

        public bool Update(Marka entity)
        {
            _unitOfWork.GetRepository<Marka>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Marka, string>> filter, Expression<Func<Marka, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Marka>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Marka>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<Marka> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}