using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Hareketler;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Service.Kartlar
{
    public class KasaService : IKasaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KasaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Kasa, bool>> filter)
        {
            return _unitOfWork.GetRepository<Kasa>().Any(filter);
        }

        public int Count(Expression<Func<Kasa, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Kasa>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Kasa>().Delete(id);
        }

        public void Delete(Kasa entity)
        {
            _unitOfWork.GetRepository<Kasa>().Delete(entity);
        }

        public void Delete(Expression<Func<Kasa, bool>> filter)
        {
            _unitOfWork.GetRepository<Kasa>().Delete(filter);
        }

        public Kasa Get(Expression<Func<Kasa, bool>> filter)
        {
            return _unitOfWork.GetRepository<Kasa>().Get(filter);
        }

        public KasaEditDto GetDto(Expression<Func<Kasa, bool>> filter)
        {
            Kasa kasa = _unitOfWork.GetRepository<Kasa>().Get(filter, a => a.OzelKod1);

            decimal bakiye =
                _unitOfWork.GetRepository<KasaHareket>().GetAll(a => a.KasaId == kasa.Id && a.GC == "G" && a.Silindi == false).Sum(a => a.Tutar) -
                _unitOfWork.GetRepository<KasaHareket>().GetAll(a => a.KasaId == kasa.Id && a.GC == "C" && a.Silindi == false).Sum(a => a.Tutar);

            KasaEditDto kasaSingle = new KasaEditDto
            {
                Id = kasa.Id,
                Kod = kasa.Kod,
                KasaAdi = kasa.KasaAdi,
                Yetkili = kasa.Yetkili,
                OzelKod1Id = kasa.OzelKod1 == null ? null : kasa.OzelKod1Id,
                Aciklama = kasa.Aciklama,
                Durum = kasa.Durum,
                Bakiye = bakiye
            };

            return kasaSingle;
        }

        public IEnumerable<Kasa> GetAll(Expression<Func<Kasa, bool>> filter = null, Func<IQueryable<Kasa>, IOrderedQueryable<Kasa>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Kasa>().GetAll(filter, orderBy);
        }

        public IEnumerable<KasaListDto> GetAllDto(Expression<Func<Kasa, bool>> filter = null, Func<IQueryable<Kasa>, IOrderedQueryable<Kasa>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<Kasa>().GetAll(filter, orderBy, a => a.OzelKod1)
                .GroupJoin(
                    _unitOfWork.GetRepository<KasaHareket>().GetAll(a => a.Silindi == false),
                     kasa => kasa.Id, hareket => hareket.KasaId,
                    (kasa, hareket) => new KasaListDto
                    {
                        Id = kasa.Id,
                        Kod = kasa.Kod,
                        KasaAdi = kasa.KasaAdi,
                        Yetkili = kasa.Yetkili,
                        OzelKod1Adi = kasa.OzelKod1 == null ? String.Empty : kasa.OzelKod1.OzelKodAdi,
                        Aciklama = kasa.Aciklama,
                        Bakiye = hareket.Where(a => a.GC == "G" && a.Silindi == false).Sum(a => a.Tutar) -
                                 hareket.Where(a => a.GC == "C" && a.Silindi == false).Sum(a => a.Tutar)
                    }
                ).ToList();

            return result;
        }

        public Kasa GetById(int id)
        {
            return _unitOfWork.GetRepository<Kasa>().GetById(id);
        }

        public bool Insert(Kasa entity)
        {
            _unitOfWork.GetRepository<Kasa>().Insert(entity);
            return true;
        }

        public bool Update(Kasa entity)
        {
            _unitOfWork.GetRepository<Kasa>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Kasa, string>> filter, Expression<Func<Kasa, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Kasa>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Kasa>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}