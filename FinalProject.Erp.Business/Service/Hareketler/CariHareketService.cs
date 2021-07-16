using FinalProject.Erp.Business.Abstract.Hareketler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Common.Tools;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FinalProject.Erp.Business.Service.Hareketler
{
    public class CariHareketService : ICariHareketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CariHareketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<CariHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariHareket>().Any(filter);
        }

        public int Count(Expression<Func<CariHareket, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<CariHareket>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<CariHareket>().Delete(id);
        }

        public void Delete(CariHareket entity)
        {
            _unitOfWork.GetRepository<CariHareket>().Delete(entity);
        }

        public void Delete(Expression<Func<CariHareket, bool>> filter)
        {
            _unitOfWork.GetRepository<CariHareket>().Delete(filter);
        }

        public CariHareket Get(Expression<Func<CariHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<CariHareket>().Get(filter);
        }

        public CariHareketEditDto GetDto(Expression<Func<CariHareket, bool>> filter)
        {
            CariHareket cariHareket = _unitOfWork.GetRepository<CariHareket>().Get(filter,
                a => a.Cari,
                a => a.TransferCari,
                a => a.Banka,
                a => a.Kasa
                );

            CariHareketEditDto cariHareketSingle = new CariHareketEditDto
            {
                Id = cariHareket.Id,
                Kod = cariHareket.Kod,
                CariId = cariHareket.CariId,
                TransferCariId = cariHareket.TransferCari == null ? null : cariHareket.TransferCariId,
                BankaId = cariHareket.Banka == null ? null : cariHareket.BankaId,
                KasaId = cariHareket.Kasa == null ? null : cariHareket.KasaId,
                HareketTip = cariHareket.HareketTip,
                GC = cariHareket.GC,
                Tarih = cariHareket.Tarih,
                MakbuzNo = cariHareket.MakbuzNo,
                Tutar = cariHareket.Tutar,
                Aciklama = cariHareket.Aciklama
            };

            return cariHareketSingle;
        }

        public IEnumerable<CariHareket> GetAll(Expression<Func<CariHareket, bool>> filter = null, Func<IQueryable<CariHareket>, IOrderedQueryable<CariHareket>> orderBy = null)
        {
            return _unitOfWork.GetRepository<CariHareket>().GetAll(filter, orderBy);
        }

        public IEnumerable<CariHareketListDto> GetAllDto(Expression<Func<CariHareket, bool>> filter = null, Func<IQueryable<CariHareket>, IOrderedQueryable<CariHareket>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<CariHareket>().GetAll(filter, orderBy,
                a => a.Cari,
                a => a.TransferCari,
                a => a.Banka,
                a => a.Kasa
                ).Select(cariHareket => new CariHareketListDto
                {
                    Id = cariHareket.Id,
                    Kod = cariHareket.Kod,
                    CariUnvani = cariHareket.Cari.CariUnvani,
                    TransferCariUnvani = cariHareket.TransferCari == null ? String.Empty : cariHareket.TransferCari.CariUnvani,
                    BankaAdi = cariHareket.Banka == null ? String.Empty : cariHareket.Banka.BankaAdi,
                    KasaAdi = cariHareket.Kasa == null ? String.Empty : cariHareket.Kasa.KasaAdi,
                    HareketTip = cariHareket.HareketTip,
                    Tarih = cariHareket.Tarih,
                    MakbuzNo = cariHareket.MakbuzNo,
                    Tutar = cariHareket.Tutar,
                    Aciklama = cariHareket.Aciklama
                }).ToList();

            return result;
        }

        public CariHareket GetById(int id)
        {
            return _unitOfWork.GetRepository<CariHareket>().GetById(id);
        }

        public bool Insert(CariHareket entity)
        {
            _unitOfWork.GetRepository<CariHareket>().Insert(entity);
            return true;
        }

        public bool Update(CariHareket entity)
        {
            _unitOfWork.GetRepository<CariHareket>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<CariHareket, string>> filter, Expression<Func<CariHareket, bool>> where = null)
        {
            return _unitOfWork.GetRepository<CariHareket>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            CariHareket entity = GetById(id);
            if (hide)
            {
                entity.SilenId = ErpVariables.AktifPersonelId;
                entity.SilinmeTarih = DateTime.Now;
            }
            else
            {
                entity.GeriAlanId = ErpVariables.AktifPersonelId;
                entity.GeriAlmaTarih = DateTime.Now;
            }
            Update(entity);

            //diğer hareket tablolarında karşılığı varsa onları da Silindi yap

            //Cari Transfer diğer cari işlemidir
            if (entity.HareketTip == TumCariIslemler.CariTransfer)
            {
                CariHareket transfer = _unitOfWork.GetRepository<CariHareket>().GetAll()
                    .Where(a => a.TransferCariId == entity.CariId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (transfer != null)
                {
                    _unitOfWork.GetRepository<CariHareket>().RecordHide(transfer.Id, true);
                }
            }

            //Nakit Tahsilat ve Nakit Ödeme Kasa işlemidir
            if (entity.HareketTip == TumCariIslemler.NakitTahsilat || entity.HareketTip == TumCariIslemler.NakitOdeme)
            {
                KasaHareket kasaHareket = _unitOfWork.GetRepository<KasaHareket>().GetAll().Where(a => a.CariId == entity.CariId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (kasaHareket != null)
                {
                    _unitOfWork.GetRepository<CariHareket>().RecordHide(kasaHareket.Id, true);
                }
            }

            _unitOfWork.GetRepository<CariHareket>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}