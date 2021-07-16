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
    public class CariGrubuService : ICariGrubuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CariGrubuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<CariGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariGrubu>().Any(filter);
        }

        public int Count(Expression<Func<CariGrubu, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<CariGrubu>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<CariGrubu>().Delete(id);
        }

        public void Delete(CariGrubu entity)
        {
            _unitOfWork.GetRepository<CariGrubu>().Delete(entity);
        }

        public void Delete(Expression<Func<CariGrubu, bool>> filter)
        {
            _unitOfWork.GetRepository<CariGrubu>().Delete(filter);
        }

        public CariGrubu Get(Expression<Func<CariGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariGrubu>().Get(filter);
        }

        public IEnumerable<CariGrubu> GetAll(Expression<Func<CariGrubu, bool>> filter = null, Func<IQueryable<CariGrubu>, IOrderedQueryable<CariGrubu>> orderBy = null)
        {
            return _unitOfWork.GetRepository<CariGrubu>().GetAll(filter, orderBy);
        }

        public CariGrubu GetById(int id)
        {
            return _unitOfWork.GetRepository<CariGrubu>().GetById(id);
        }

        public bool Insert(CariGrubu entity)
        {
            _unitOfWork.GetRepository<CariGrubu>().Insert(entity);
            return true;
        }

        public bool Update(CariGrubu entity)
        {
            _unitOfWork.GetRepository<CariGrubu>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<CariGrubu, string>> filter, Expression<Func<CariGrubu, bool>> where = null)
        {
            return _unitOfWork.GetRepository<CariGrubu>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<CariGrubu>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<CariGrubu> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}