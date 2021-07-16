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
    public class StokGrubuService : IStokGrubuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StokGrubuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<StokGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokGrubu>().Any(filter);
        }

        public int Count(Expression<Func<StokGrubu, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<StokGrubu>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<StokGrubu>().Delete(id);
        }

        public void Delete(StokGrubu entity)
        {
            _unitOfWork.GetRepository<StokGrubu>().Delete(entity);
        }

        public void Delete(Expression<Func<StokGrubu, bool>> filter)
        {
            _unitOfWork.GetRepository<StokGrubu>().Delete(filter);
        }

        public StokGrubu Get(Expression<Func<StokGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokGrubu>().Get(filter);
        }

        public IEnumerable<StokGrubu> GetAll(Expression<Func<StokGrubu, bool>> filter = null, Func<IQueryable<StokGrubu>, IOrderedQueryable<StokGrubu>> orderBy = null)
        {
            return _unitOfWork.GetRepository<StokGrubu>().GetAll(filter, orderBy);
        }

        public StokGrubu GetById(int id)
        {
            return _unitOfWork.GetRepository<StokGrubu>().GetById(id);
        }

        public bool Insert(StokGrubu entity)
        {
            _unitOfWork.GetRepository<StokGrubu>().Insert(entity);
            return true;
        }

        public bool Update(StokGrubu entity)
        {
            _unitOfWork.GetRepository<StokGrubu>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<StokGrubu, string>> filter, Expression<Func<StokGrubu, bool>> where = null)
        {
            return _unitOfWork.GetRepository<StokGrubu>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<StokGrubu>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<StokGrubu> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}