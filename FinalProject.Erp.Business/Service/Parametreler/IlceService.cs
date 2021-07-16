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
    public class IlceService : IIlceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IlceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Ilce, bool>> filter)
        {
            return _unitOfWork.GetRepository<Ilce>().Any(filter);
        }

        public int Count(Expression<Func<Ilce, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Ilce>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Ilce>().Delete(id);
        }

        public void Delete(Ilce entity)
        {
            _unitOfWork.GetRepository<Ilce>().Delete(entity);
        }

        public void Delete(Expression<Func<Ilce, bool>> filter)
        {
            _unitOfWork.GetRepository<Ilce>().Delete(filter);
        }

        public Ilce Get(Expression<Func<Ilce, bool>> filter)
        {
            return _unitOfWork.GetRepository<Ilce>().Get(filter);
        }

        public IEnumerable<Ilce> GetAll(Expression<Func<Ilce, bool>> filter = null, Func<IQueryable<Ilce>, IOrderedQueryable<Ilce>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Ilce>().GetAll(filter, orderBy);
        }

        public Ilce GetById(int id)
        {
            return _unitOfWork.GetRepository<Ilce>().GetById(id);
        }

        public bool Insert(Ilce entity)
        {
            _unitOfWork.GetRepository<Ilce>().Insert(entity);
            return true;
        }

        public bool Update(Ilce entity)
        {
            _unitOfWork.GetRepository<Ilce>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Ilce, string>> filter, Expression<Func<Ilce, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Ilce>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Ilce>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<Ilce> GetAllByActiveCars(int sehirId, bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false & a.SehirId == sehirId).ToList();
        }
    }
}