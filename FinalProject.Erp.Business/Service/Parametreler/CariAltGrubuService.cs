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
    public class CariAltGrubuService : ICariAltGrubuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CariAltGrubuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<CariAltGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().Any(filter);
        }

        public int Count(Expression<Func<CariAltGrubu, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().Delete(id);
        }

        public void Delete(CariAltGrubu entity)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().Delete(entity);
        }

        public void Delete(Expression<Func<CariAltGrubu, bool>> filter)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().Delete(filter);
        }

        public CariAltGrubu Get(Expression<Func<CariAltGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().Get(filter);
        }

        public IEnumerable<CariAltGrubu> GetAll(Expression<Func<CariAltGrubu, bool>> filter = null, Func<IQueryable<CariAltGrubu>, IOrderedQueryable<CariAltGrubu>> orderBy = null)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().GetAll(filter, orderBy);
        }

        public CariAltGrubu GetById(int id)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().GetById(id);
        }

        public bool Insert(CariAltGrubu entity)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().Insert(entity);
            return true;
        }

        public bool Update(CariAltGrubu entity)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<CariAltGrubu, string>> filter, Expression<Func<CariAltGrubu, bool>> where = null)
        {
            return _unitOfWork.GetRepository<CariAltGrubu>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<CariAltGrubu>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<CariAltGrubu> GetAllByActiveCars(int cariGrubuId, bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false & a.CariGrubuId == cariGrubuId).ToList();
        }
    }
}