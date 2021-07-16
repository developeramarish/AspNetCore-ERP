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
    public class BankaService : IBankaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Banka, bool>> filter)
        {
            return _unitOfWork.GetRepository<Banka>().Any(filter);
        }

        public int Count(Expression<Func<Banka, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Banka>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Banka>().Delete(id);
        }

        public void Delete(Banka entity)
        {
            _unitOfWork.GetRepository<Banka>().Delete(entity);
        }

        public void Delete(Expression<Func<Banka, bool>> filter)
        {
            _unitOfWork.GetRepository<Banka>().Delete(filter);
        }

        public Banka Get(Expression<Func<Banka, bool>> filter)
        {
            return _unitOfWork.GetRepository<Banka>().Get(filter);
        }

        public BankaEditDto GetDto(Expression<Func<Banka, bool>> filter)
        {
            Banka banka = _unitOfWork.GetRepository<Banka>().Get(filter, a => a.OzelKod1);

            decimal bakiye =
                _unitOfWork.GetRepository<BankaHareket>().GetAll(a => a.BankaId == banka.Id && a.GC == "G" && a.Silindi == false).Sum(a => a.Tutar) -
                _unitOfWork.GetRepository<BankaHareket>().GetAll(a => a.BankaId == banka.Id && a.GC == "C" && a.Silindi == false).Sum(a => a.Tutar);

            BankaEditDto bankaSingle = new BankaEditDto
            {
                Id = banka.Id,
                Kod = banka.Kod,
                BankaAdi = banka.BankaAdi,
                BankaSube = banka.BankaSube,
                HesapNo = banka.HesapNo,
                IbanNo = banka.IbanNo,
                Yetkili = banka.Yetkili,
                Telefon = banka.Telefon,
                Faks = banka.Faks,
                Gsm = banka.Gsm,
                OzelKod1Id = banka.OzelKod1 == null ? null : banka.OzelKod1Id,
                Email = banka.Email,
                Web = banka.Web,
                Durum = banka.Durum,
                Aciklama = banka.Aciklama,
                Bakiye = bakiye
            };

            return bankaSingle;
        }

        public IEnumerable<Banka> GetAll(Expression<Func<Banka, bool>> filter = null, Func<IQueryable<Banka>, IOrderedQueryable<Banka>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Banka>().GetAll(filter, orderBy);
        }

        public IEnumerable<BankaListDto> GetAllDto(Expression<Func<Banka, bool>> filter = null, Func<IQueryable<Banka>, IOrderedQueryable<Banka>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<Banka>().GetAll(filter, orderBy, a => a.OzelKod1)
                .GroupJoin(
                    _unitOfWork.GetRepository<BankaHareket>().GetAll(a => a.Silindi == false),
                     banka => banka.Id, hareket => hareket.BankaId,
                    (banka, hareket) => new BankaListDto
                    {
                        Id = banka.Id,
                        Kod = banka.Kod,
                        BankaAdi = banka.BankaAdi,
                        BankaSube = banka.BankaSube,
                        HesapNo = banka.HesapNo,
                        IbanNo = banka.IbanNo,
                        Yetkili = banka.Yetkili,
                        Telefon = banka.Telefon,
                        Faks = banka.Faks,
                        Gsm = banka.Gsm,
                        OzelKod1Adi = banka.OzelKod1 == null ? String.Empty : banka.OzelKod1.OzelKodAdi,
                        Email = banka.Email,
                        Web = banka.Web,
                        Aciklama = banka.Aciklama,
                        Bakiye = hareket.Where(a => a.GC == "G").Sum(a => a.Tutar) - hareket.Where(a => a.GC == "C").Sum(a => a.Tutar)
                    }
                ).ToList();

            return result;
        }

        public Banka GetById(int id)
        {
            return _unitOfWork.GetRepository<Banka>().GetById(id);
        }

        public bool Insert(Banka entity)
        {
            _unitOfWork.GetRepository<Banka>().Insert(entity);
            return true;
        }

        public bool Update(Banka entity)
        {
            _unitOfWork.GetRepository<Banka>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Banka, string>> filter, Expression<Func<Banka, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Banka>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Banka>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}