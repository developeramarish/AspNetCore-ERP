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
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<ModelKart, bool>> filter)
        {
            return _unitOfWork.GetRepository<ModelKart>().Any(filter);
        }

        public int Count(Expression<Func<ModelKart, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<ModelKart>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<ModelKart>().Delete(id);
        }

        public void Delete(ModelKart entity)
        {
            _unitOfWork.GetRepository<ModelKart>().Delete(entity);
        }

        public void Delete(Expression<Func<ModelKart, bool>> filter)
        {
            _unitOfWork.GetRepository<ModelKart>().Delete(filter);
        }

        public ModelKart Get(Expression<Func<ModelKart, bool>> filter)
        {
            return _unitOfWork.GetRepository<ModelKart>().Get(filter);
        }

        public IEnumerable<ModelKart> GetAll(Expression<Func<ModelKart, bool>> filter = null, Func<IQueryable<ModelKart>, IOrderedQueryable<ModelKart>> orderBy = null)
        {
            return _unitOfWork.GetRepository<ModelKart>().GetAll(filter, orderBy);
        }

        public ModelKart GetById(int id)
        {
            return _unitOfWork.GetRepository<ModelKart>().GetById(id);
        }

        public bool Insert(ModelKart entity)
        {
            _unitOfWork.GetRepository<ModelKart>().Insert(entity);
            return true;
        }

        public bool Update(ModelKart entity)
        {
            _unitOfWork.GetRepository<ModelKart>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<ModelKart, string>> filter, Expression<Func<ModelKart, bool>> where = null)
        {
            return _unitOfWork.GetRepository<ModelKart>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<ModelKart>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<ModelKart> GetAllByActiveCars(int markaId, bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false & a.MarkaId == markaId).ToList();
        }
    }
}