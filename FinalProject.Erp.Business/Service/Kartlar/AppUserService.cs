using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Service.Kartlar
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<AppUser, bool>> filter)
        {
            return _unitOfWork.GetRepository<AppUser>().Any(filter);
        }

        public int Count(Expression<Func<AppUser, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<AppUser>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<AppUser>().Delete(id);
        }

        public void Delete(AppUser entity)
        {
            _unitOfWork.GetRepository<AppUser>().Delete(entity);
        }

        public void Delete(Expression<Func<AppUser, bool>> filter)
        {
            _unitOfWork.GetRepository<AppUser>().Delete(filter);
        }

        public AppUser Get(Expression<Func<AppUser, bool>> filter)
        {
            return _unitOfWork.GetRepository<AppUser>().Get(filter);
        }

        public IEnumerable<AppUser> GetAll(Expression<Func<AppUser, bool>> filter = null, Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>> orderBy = null)
        {
            return _unitOfWork.GetRepository<AppUser>().GetAll(filter, orderBy);
        }

        public AppUser GetById(int id)
        {
            return _unitOfWork.GetRepository<AppUser>().GetById(id);
        }

        public bool Insert(AppUser entity)
        {
            _unitOfWork.GetRepository<AppUser>().Insert(entity);
            return true;
        }

        public bool Update(AppUser entity)
        {
            _unitOfWork.GetRepository<AppUser>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<AppUser, string>> filter, Expression<Func<AppUser, bool>> where = null)
        {
            return _unitOfWork.GetRepository<AppUser>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<AppUser>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}