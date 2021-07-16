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
    public class CariService : ICariService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CariService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Cari, bool>> filter)
        {
            return _unitOfWork.GetRepository<Cari>().Any(filter);
        }

        public int Count(Expression<Func<Cari, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Cari>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Cari>().Delete(id);
        }

        public void Delete(Cari entity)
        {
            _unitOfWork.GetRepository<Cari>().Delete(entity);
        }

        public void Delete(Expression<Func<Cari, bool>> filter)
        {
            _unitOfWork.GetRepository<Cari>().Delete(filter);
        }

        public Cari Get(Expression<Func<Cari, bool>> filter)
        {
            return _unitOfWork.GetRepository<Cari>().Get(filter);
        }

        public CariEditDto GetDto(Expression<Func<Cari, bool>> filter)
        {
            Cari cari = _unitOfWork.GetRepository<Cari>().Get(filter,
                a => a.CariGrubu,
                a => a.CariAltGrubu,
                a => a.Ulke,
                a => a.Sehir,
                a => a.Ilce,
                a => a.OzelKod1,
                a => a.OzelKod2,
                a => a.OzelKod3
            );

            decimal bakiye =
                _unitOfWork.GetRepository<CariHareket>().GetAll(a => a.CariId == cari.Id && a.GC == "G" && a.Silindi == false).Sum(a => a.Tutar) -
                _unitOfWork.GetRepository<CariHareket>().GetAll(a => a.CariId == cari.Id && a.GC == "C" && a.Silindi == false).Sum(a => a.Tutar);

            CariEditDto cariSingle = new CariEditDto
            {
                Id = cari.Id,
                Kod = cari.Kod,
                CariTipi = cari.CariTipi,
                CariUnvani = cari.CariUnvani,
                Yetkili = cari.Yetkili,
                CariGrubuId = cari.CariGrubu == null ? null : cari.CariGrubuId,
                CariAltGrubuId = cari.CariAltGrubu == null ? null : cari.CariAltGrubuId,
                FiyatGrubu = cari.FiyatGrubu,
                VergiDaire = cari.VergiDaire,
                VergiNo = cari.VergiNo,
                TcKimlikNo = cari.TcKimlikNo,
                Adres = cari.Adres,
                UlkeId = cari.Ulke == null ? null : cari.UlkeId,
                SehirId = cari.Sehir == null ? null : cari.SehirId,
                IlceId = cari.Ilce == null ? null : cari.IlceId,
                Telefon = cari.Telefon,
                Faks = cari.Faks,
                Gsm = cari.Gsm,
                Email = cari.Email,
                Web = cari.Web,
                OzelKod1Id = cari.OzelKod1 == null ? null : cari.OzelKod1Id,
                OzelKod2Id = cari.OzelKod2 == null ? null : cari.OzelKod2Id,
                OzelKod3Id = cari.OzelKod3 == null ? null : cari.OzelKod3Id,
                Aciklama = cari.Aciklama,
                Durum = cari.Durum,
                Bakiye = bakiye
            };

            return cariSingle;
        }

        public IEnumerable<Cari> GetAll(Expression<Func<Cari, bool>> filter = null, Func<IQueryable<Cari>, IOrderedQueryable<Cari>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Cari>().GetAll(filter, orderBy);
        }

        public IEnumerable<CariListDto> GetAllDto(Expression<Func<Cari, bool>> filter = null, Func<IQueryable<Cari>, IOrderedQueryable<Cari>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<Cari>().GetAll(filter, orderBy,
                a => a.CariGrubu,
                a => a.CariAltGrubu,
                a => a.Ulke,
                a => a.Sehir,
                a => a.Ilce,
                a => a.OzelKod1,
                a => a.OzelKod2,
                a => a.OzelKod3
                )
                .GroupJoin(
                    _unitOfWork.GetRepository<CariHareket>().GetAll(a => a.Silindi == false),
                     cari => cari.Id, hareket => hareket.CariId,
                    (cari, hareket) => new CariListDto
                    {
                        Id = cari.Id,
                        Kod = cari.Kod,
                        CariTipi = cari.CariTipi,
                        CariUnvani = cari.CariUnvani,
                        Yetkili = cari.Yetkili,
                        CariGrubuAdi = cari.CariGrubu == null ? String.Empty : cari.CariGrubu.CariGrubuAdi,
                        CariAltGrubuAdi = cari.CariAltGrubu == null ? String.Empty : cari.CariAltGrubu.CariAltGrubuAdi,
                        FiyatGrubu = cari.FiyatGrubu,
                        VergiDaire = cari.VergiDaire,
                        VergiNo = cari.VergiNo,
                        TcKimlikNo = cari.TcKimlikNo,
                        Adres = cari.Adres,
                        UlkeAdi = cari.Ulke == null ? String.Empty : cari.Ulke.UlkeAdi,
                        SehirAdi = cari.Sehir == null ? String.Empty : cari.Sehir.SehirAdi,
                        IlceAdi = cari.Ilce == null ? String.Empty : cari.Ilce.IlceAdi,
                        Telefon = cari.Telefon,
                        Faks = cari.Faks,
                        Gsm = cari.Gsm,
                        Email = cari.Email,
                        Web = cari.Web,
                        OzelKod1Adi = cari.OzelKod1 == null ? String.Empty : cari.OzelKod1.OzelKodAdi,
                        OzelKod2Adi = cari.OzelKod2 == null ? String.Empty : cari.OzelKod2.OzelKodAdi,
                        OzelKod3Adi = cari.OzelKod3 == null ? String.Empty : cari.OzelKod3.OzelKodAdi,
                        Aciklama = cari.Aciklama,
                        Bakiye = hareket.Where(a => a.GC == "G").Sum(a => a.Tutar) - hareket.Where(a => a.GC == "C").Sum(a => a.Tutar)
                    }
                ).ToList();

            return result;
        }

        public Cari GetById(int id)
        {
            return _unitOfWork.GetRepository<Cari>().GetById(id);
        }

        public bool Insert(Cari entity)
        {
            _unitOfWork.GetRepository<Cari>().Insert(entity);
            return true;
        }

        public bool Update(Cari entity)
        {
            _unitOfWork.GetRepository<Cari>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Cari, string>> filter, Expression<Func<Cari, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Cari>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Cari>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}