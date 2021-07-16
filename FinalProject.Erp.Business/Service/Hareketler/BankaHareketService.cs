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
    public class BankaHareketService : IBankaHareketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankaHareketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<BankaHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<BankaHareket>().Any(filter);
        }

        public int Count(Expression<Func<BankaHareket, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<BankaHareket>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<BankaHareket>().Delete(id);
        }

        public void Delete(BankaHareket entity)
        {
            _unitOfWork.GetRepository<BankaHareket>().Delete(entity);
        }

        public void Delete(Expression<Func<BankaHareket, bool>> filter)
        {
            _unitOfWork.GetRepository<BankaHareket>().Delete(filter);
        }

        public BankaHareket Get(Expression<Func<BankaHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<BankaHareket>().Get(filter);
        }

        public BankaHareketEditDto GetDto(Expression<Func<BankaHareket, bool>> filter)
        {
            BankaHareket bankaHareket = _unitOfWork.GetRepository<BankaHareket>().Get(filter,
                a => a.Banka,
                a => a.TransferBanka,
                a => a.Cari,
                a => a.Kasa
                );

            BankaHareketEditDto bankaHareketSingle = new BankaHareketEditDto
            {
                Id = bankaHareket.Id,
                Kod = bankaHareket.Kod,
                BankaId = bankaHareket.BankaId,
                TransferBankaId = bankaHareket.TransferBanka == null ? null : bankaHareket.TransferBankaId,
                CariId = bankaHareket.Cari == null ? null : bankaHareket.CariId,
                KasaId = bankaHareket.Kasa == null ? null : bankaHareket.KasaId,
                HareketTip = bankaHareket.HareketTip,
                GC = bankaHareket.GC,
                Tarih = bankaHareket.Tarih,
                MakbuzNo = bankaHareket.MakbuzNo,
                Tutar = bankaHareket.Tutar,
                Aciklama = bankaHareket.Aciklama
            };

            return bankaHareketSingle;
        }

        public IEnumerable<BankaHareket> GetAll(Expression<Func<BankaHareket, bool>> filter = null, Func<IQueryable<BankaHareket>, IOrderedQueryable<BankaHareket>> orderBy = null)
        {
            return _unitOfWork.GetRepository<BankaHareket>().GetAll(filter, orderBy);
        }

        public IEnumerable<BankaHareketListDto> GetAllDto(Expression<Func<BankaHareket, bool>> filter = null, Func<IQueryable<BankaHareket>, IOrderedQueryable<BankaHareket>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<BankaHareket>().GetAll(filter, orderBy,
                a => a.Banka,
                a => a.TransferBanka,
                a => a.Cari,
                a => a.Kasa
                ).Select(bankaHareket => new BankaHareketListDto
                {
                    Id = bankaHareket.Id,
                    Kod = bankaHareket.Kod,
                    BankaAdi = bankaHareket.Banka.BankaAdi,
                    TransferBankaAdi = bankaHareket.TransferBanka == null ? String.Empty : bankaHareket.TransferBanka.BankaAdi,
                    CariUnvani = bankaHareket.Cari == null ? String.Empty : bankaHareket.Cari.CariUnvani,
                    KasaAdi = bankaHareket.Kasa == null ? String.Empty : bankaHareket.Kasa.KasaAdi,
                    HareketTip = bankaHareket.HareketTip,
                    Tarih = bankaHareket.Tarih,
                    MakbuzNo = bankaHareket.MakbuzNo,
                    Tutar = bankaHareket.Tutar,
                    Aciklama = bankaHareket.Aciklama
                }).ToList();

            return result;
        }

        public BankaHareket GetById(int id)
        {
            return _unitOfWork.GetRepository<BankaHareket>().GetById(id);
        }

        public bool Insert(BankaHareket entity)
        {
            _unitOfWork.GetRepository<BankaHareket>().Insert(entity);
            return true;
        }

        public bool Update(BankaHareket entity)
        {
            _unitOfWork.GetRepository<BankaHareket>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<BankaHareket, string>> filter, Expression<Func<BankaHareket, bool>> where = null)
        {
            return _unitOfWork.GetRepository<BankaHareket>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            BankaHareket entity = GetById(id);
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

            //Banka Transfer diğer banka işlemidir
            if (entity.HareketTip == TumBankaIslemler.BankaTransfer)
            {
                BankaHareket transfer = _unitOfWork.GetRepository<BankaHareket>().GetAll()
                    .Where(a => a.TransferBankaId == entity.BankaId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (transfer != null)
                {
                    _unitOfWork.GetRepository<BankaHareket>().RecordHide(transfer.Id, true);
                }
            }

            //Gelen Giden Havale Cari işlemidir
            if (entity.HareketTip == TumBankaIslemler.GelenHavale || entity.HareketTip == TumBankaIslemler.GidenHavale)
            {
                CariHareket cariHareket = _unitOfWork.GetRepository<CariHareket>().GetAll()
                    .Where(a => a.BankaId == entity.BankaId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (cariHareket != null)
                {
                    _unitOfWork.GetRepository<CariHareket>().RecordHide(cariHareket.Id, true);
                }
            }

            //Para Çekme ve Yatırma Kasa işlemidir
            if (entity.HareketTip == TumBankaIslemler.BankayaParaYatirma || entity.HareketTip == TumBankaIslemler.BankadanParaCekme)
            {
                KasaHareket kasaHareket = _unitOfWork.GetRepository<KasaHareket>().GetAll()
                    .Where(a => a.BankaId == entity.BankaId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (kasaHareket != null)
                {
                    _unitOfWork.GetRepository<CariHareket>().RecordHide(kasaHareket.Id, true);
                }
            }

            _unitOfWork.GetRepository<BankaHareket>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}