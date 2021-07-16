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
    public class OzelKodService : IOzelKodService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OzelKodService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<OzelKod, bool>> filter)
        {
            return _unitOfWork.GetRepository<OzelKod>().Any(filter);
        }

        public int Count(Expression<Func<OzelKod, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<OzelKod>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<OzelKod>().Delete(id);
        }

        public void Delete(OzelKod entity)
        {
            _unitOfWork.GetRepository<OzelKod>().Delete(entity);
        }

        public void Delete(Expression<Func<OzelKod, bool>> filter)
        {
            _unitOfWork.GetRepository<OzelKod>().Delete(filter);
        }

        public OzelKod Get(Expression<Func<OzelKod, bool>> filter)
        {
            return _unitOfWork.GetRepository<OzelKod>().Get(filter);
        }

        public IEnumerable<OzelKod> GetAll(Expression<Func<OzelKod, bool>> filter = null, Func<IQueryable<OzelKod>, IOrderedQueryable<OzelKod>> orderBy = null)
        {
            return _unitOfWork.GetRepository<OzelKod>().GetAll(filter, orderBy);
        }

        public OzelKod GetById(int id)
        {
            return _unitOfWork.GetRepository<OzelKod>().GetById(id);
        }

        public bool Insert(OzelKod entity)
        {
            _unitOfWork.GetRepository<OzelKod>().Insert(entity);
            return true;
        }

        public bool Update(OzelKod entity)
        {
            _unitOfWork.GetRepository<OzelKod>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<OzelKod, string>> filter, Expression<Func<OzelKod, bool>> where = null)
        {
            return _unitOfWork.GetRepository<OzelKod>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<OzelKod>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<OzelKod> GetAllByActiveCars(bool durum, OzelKodKart kart, OzelKodSira sira)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false & a.OzelKodTip == (int)kart & a.OzelKodSira == (int)sira).ToList();
        }
    }
}