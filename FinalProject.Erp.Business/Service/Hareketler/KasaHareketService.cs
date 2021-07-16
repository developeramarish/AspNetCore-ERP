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
    public class KasaHareketService : IKasaHareketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KasaHareketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<KasaHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<KasaHareket>().Any(filter);
        }

        public int Count(Expression<Func<KasaHareket, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<KasaHareket>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<KasaHareket>().Delete(id);
        }

        public void Delete(KasaHareket entity)
        {
            _unitOfWork.GetRepository<KasaHareket>().Delete(entity);
        }

        public void Delete(Expression<Func<KasaHareket, bool>> filter)
        {
            _unitOfWork.GetRepository<KasaHareket>().Delete(filter);
        }

        public KasaHareket Get(Expression<Func<KasaHareket, bool>> filter)
        {
            return _unitOfWork.GetRepository<KasaHareket>().Get(filter);
        }

        public KasaHareketEditDto GetDto(Expression<Func<KasaHareket, bool>> filter)
        {
            KasaHareket kasaHareket = _unitOfWork.GetRepository<KasaHareket>().Get(filter,
                a => a.Kasa,
                a => a.TransferKasa,
                a => a.Cari,
                a => a.Banka
                );

            KasaHareketEditDto kasaHareketSingle = new KasaHareketEditDto
            {
                Id = kasaHareket.Id,
                Kod = kasaHareket.Kod,
                KasaId = kasaHareket.KasaId,
                TransferKasaId = kasaHareket.TransferKasa == null ? null : kasaHareket.TransferKasaId,
                CariId = kasaHareket.Cari == null ? null : kasaHareket.CariId,
                BankaId = kasaHareket.Banka == null ? null : kasaHareket.BankaId,
                HareketTip = kasaHareket.HareketTip,
                GC = kasaHareket.GC,
                Tarih = kasaHareket.Tarih,
                MakbuzNo = kasaHareket.MakbuzNo,
                Tutar = kasaHareket.Tutar,
                Aciklama = kasaHareket.Aciklama
            };

            return kasaHareketSingle;
        }

        public IEnumerable<KasaHareket> GetAll(Expression<Func<KasaHareket, bool>> filter = null, Func<IQueryable<KasaHareket>, IOrderedQueryable<KasaHareket>> orderBy = null)
        {
            return _unitOfWork.GetRepository<KasaHareket>().GetAll(filter, orderBy);
        }

        public IEnumerable<KasaHareketListDto> GetAllDto(Expression<Func<KasaHareket, bool>> filter = null, Func<IQueryable<KasaHareket>, IOrderedQueryable<KasaHareket>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<KasaHareket>().GetAll(filter, orderBy,
                a => a.Kasa,
                a => a.TransferKasa,
                a => a.Cari,
                a => a.Banka
                ).Select(kasaHareket => new KasaHareketListDto
                {
                    Id = kasaHareket.Id,
                    Kod = kasaHareket.Kod,
                    KasaAdi = kasaHareket.Kasa.KasaAdi,
                    TransferKasaAdi = kasaHareket.TransferKasa == null ? String.Empty : kasaHareket.TransferKasa.KasaAdi,
                    CariUnvani = kasaHareket.Cari == null ? String.Empty : kasaHareket.Cari.CariUnvani,
                    BankaAdi = kasaHareket.Banka == null ? String.Empty : kasaHareket.Banka.BankaAdi,
                    HareketTip = kasaHareket.HareketTip,
                    Tarih = kasaHareket.Tarih,
                    MakbuzNo = kasaHareket.MakbuzNo,
                    Tutar = kasaHareket.Tutar,
                    Aciklama = kasaHareket.Aciklama
                }).ToList();

            return result;
        }

        public KasaHareket GetById(int id)
        {
            return _unitOfWork.GetRepository<KasaHareket>().GetById(id);
        }

        public bool Insert(KasaHareket entity)
        {
            _unitOfWork.GetRepository<KasaHareket>().Insert(entity);
            return true;
        }

        public bool Update(KasaHareket entity)
        {
            _unitOfWork.GetRepository<KasaHareket>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<KasaHareket, string>> filter, Expression<Func<KasaHareket, bool>> where = null)
        {
            return _unitOfWork.GetRepository<KasaHareket>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            KasaHareket entity = GetById(id);
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

            //Kasa Transfer diğer kasa işlemidir
            if (entity.HareketTip == TumKasaIslemler.KasaTransfer)
            {
                KasaHareket transfer = _unitOfWork.GetRepository<KasaHareket>().GetAll()
                    .Where(a => a.TransferKasaId == entity.KasaId && a.Kod == "T-" + entity.Kod).ToList().FirstOrDefault();
                if (transfer != null)
                {
                    _unitOfWork.GetRepository<KasaHareket>().RecordHide(transfer.Id, true);
                }
            }

            _unitOfWork.GetRepository<KasaHareket>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}