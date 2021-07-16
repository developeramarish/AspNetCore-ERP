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
    public class StokAltGrubuService : IStokAltGrubuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StokAltGrubuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<StokAltGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().Any(filter);
        }

        public int Count(Expression<Func<StokAltGrubu, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().Delete(id);
        }

        public void Delete(StokAltGrubu entity)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().Delete(entity);
        }

        public void Delete(Expression<Func<StokAltGrubu, bool>> filter)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().Delete(filter);
        }

        public StokAltGrubu Get(Expression<Func<StokAltGrubu, bool>> filter)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().Get(filter);
        }

        public IEnumerable<StokAltGrubu> GetAll(Expression<Func<StokAltGrubu, bool>> filter = null, Func<IQueryable<StokAltGrubu>, IOrderedQueryable<StokAltGrubu>> orderBy = null)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().GetAll(filter, orderBy);
        }

        public StokAltGrubu GetById(int id)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().GetById(id);
        }

        public bool Insert(StokAltGrubu entity)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().Insert(entity);
            return true;
        }

        public bool Update(StokAltGrubu entity)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<StokAltGrubu, string>> filter, Expression<Func<StokAltGrubu, bool>> where = null)
        {
            return _unitOfWork.GetRepository<StokAltGrubu>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<StokAltGrubu>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<StokAltGrubu> GetAllByActiveCars(int stokGrubuId, bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false & a.StokGrubuId == stokGrubuId).ToList();
        }
    }
}