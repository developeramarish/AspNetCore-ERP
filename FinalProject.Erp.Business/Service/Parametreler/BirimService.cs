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
    public class BirimService : IBirimService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BirimService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Birim, bool>> filter)
        {
            return _unitOfWork.GetRepository<Birim>().Any(filter);
        }

        public int Count(Expression<Func<Birim, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Birim>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Birim>().Delete(id);
        }

        public void Delete(Birim entity)
        {
            _unitOfWork.GetRepository<Birim>().Delete(entity);
        }

        public void Delete(Expression<Func<Birim, bool>> filter)
        {
            _unitOfWork.GetRepository<Birim>().Delete(filter);
        }

        public Birim Get(Expression<Func<Birim, bool>> filter)
        {
            return _unitOfWork.GetRepository<Birim>().Get(filter);
        }

        public IEnumerable<Birim> GetAll(Expression<Func<Birim, bool>> filter = null, Func<IQueryable<Birim>, IOrderedQueryable<Birim>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Birim>().GetAll(filter, orderBy);
        }

        public Birim GetById(int id)
        {
            return _unitOfWork.GetRepository<Birim>().GetById(id);
        }

        public bool Insert(Birim entity)
        {
            _unitOfWork.GetRepository<Birim>().Insert(entity);
            return true;
        }

        public bool Update(Birim entity)
        {
            _unitOfWork.GetRepository<Birim>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Birim, string>> filter, Expression<Func<Birim, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Birim>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Birim>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public List<Birim> GetAllByActiveCars(bool durum)
        {
            return GetAll(a => a.Durum == durum & a.Silindi == false).ToList();
        }
    }
}