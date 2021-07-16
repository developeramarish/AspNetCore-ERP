using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Service.Kartlar
{
    public class DepoService : IDepoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Depo, bool>> filter)
        {
            return _unitOfWork.GetRepository<Depo>().Any(filter);
        }

        public int Count(Expression<Func<Depo, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Depo>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Depo>().Delete(id);
        }

        public void Delete(Depo entity)
        {
            _unitOfWork.GetRepository<Depo>().Delete(entity);
        }

        public void Delete(Expression<Func<Depo, bool>> filter)
        {
            _unitOfWork.GetRepository<Depo>().Delete(filter);
        }

        public Depo Get(Expression<Func<Depo, bool>> filter)
        {
            return _unitOfWork.GetRepository<Depo>().Get(filter);
        }

        public DepoEditDto GetDto(Expression<Func<Depo, bool>> filter)
        {
            Depo depo = _unitOfWork.GetRepository<Depo>().Get(filter);

            DepoEditDto depoSingle = new DepoEditDto
            {
                Id = depo.Id,
                Kod = depo.Kod,
                DepoAdi = depo.DepoAdi,
                Yetkili = depo.Yetkili,
                Telefon = depo.Telefon,
                Adres = depo.Adres,
                Durum = depo.Durum,
                Aciklama = depo.Aciklama,
            };

            return depoSingle;
        }

        public IEnumerable<Depo> GetAll(Expression<Func<Depo, bool>> filter = null, Func<IQueryable<Depo>, IOrderedQueryable<Depo>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Depo>().GetAll(filter, orderBy);
        }

        public IEnumerable<DepoListDto> GetAllDto(Expression<Func<Depo, bool>> filter = null, Func<IQueryable<Depo>, IOrderedQueryable<Depo>> orderBy = null)
        {
            List<Depo> depoList = _unitOfWork.GetRepository<Depo>().GetAll(filter, orderBy).ToList();
            List<DepoListDto> result = new List<DepoListDto>();
            foreach (Depo item in depoList)
            {
                result.Add(new DepoListDto
                {
                    Id = item.Id,
                    Kod = item.Kod,
                    DepoAdi = item.DepoAdi,
                    Yetkili = item.Yetkili,
                    Telefon = item.Telefon,
                    Adres = item.Adres,
                    Aciklama = item.Aciklama,
                });
            }

            return result;
        }

        public Depo GetById(int id)
        {
            return _unitOfWork.GetRepository<Depo>().GetById(id);
        }

        public bool Insert(Depo entity)
        {
            _unitOfWork.GetRepository<Depo>().Insert(entity);
            return true;
        }

        public bool Update(Depo entity)
        {
            _unitOfWork.GetRepository<Depo>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Depo, string>> filter, Expression<Func<Depo, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Depo>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Depo>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}