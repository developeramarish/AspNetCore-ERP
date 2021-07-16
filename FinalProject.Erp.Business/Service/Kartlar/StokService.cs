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
    public class StokService : IStokService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StokService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Any(Expression<Func<Stok, bool>> filter)
        {
            return _unitOfWork.GetRepository<Stok>().Any(filter);
        }

        public int Count(Expression<Func<Stok, bool>> filter = null)
        {
            return _unitOfWork.GetRepository<Stok>().Count(filter);
        }

        public void Delete(int id)
        {
            _unitOfWork.GetRepository<Stok>().Delete(id);
        }

        public void Delete(Stok entity)
        {
            _unitOfWork.GetRepository<Stok>().Delete(entity);
        }

        public void Delete(Expression<Func<Stok, bool>> filter)
        {
            _unitOfWork.GetRepository<Stok>().Delete(filter);
        }

        public Stok Get(Expression<Func<Stok, bool>> filter)
        {
            return _unitOfWork.GetRepository<Stok>().Get(filter);
        }

        public StokEditDto GetDto(Expression<Func<Stok, bool>> filter)
        {
            Stok stok = _unitOfWork.GetRepository<Stok>().Get(filter,
                a => a.StokTur,
                a => a.StokGrubu,
                a => a.StokAltGrubu,
                a => a.Marka,
                a => a.Model,
                a => a.Birim,
                a => a.OzelKod1,
                a => a.OzelKod2,
                a => a.OzelKod3
                );

            StokEditDto stokSingle = new StokEditDto
            {
                Id = stok.Id,
                Kod = stok.Kod,
                StokTurId = stok.StokTurId,
                StokAdi = stok.StokAdi,
                StokGrubuId = stok.StokGrubu == null ? null : stok.StokGrubuId,
                StokAltGrubuId = stok.StokAltGrubu == null ? null : stok.StokAltGrubuId,
                MarkaId = stok.Marka == null ? null : stok.MarkaId,
                ModelId = stok.Model == null ? null : stok.ModelId,
                BirimId = stok.BirimId,
                Barkod = stok.Barkod,
                AlisKdv = stok.AlisKdv,
                SatisKdv = stok.SatisKdv,
                AlisKdvDurum = stok.AlisKdvDurum,
                SatisKdvDurum = stok.SatisKdvDurum,
                AlisFiyat1 = stok.AlisFiyat1,
                AlisFiyat2 = stok.AlisFiyat2,
                AlisFiyat3 = stok.AlisFiyat3,
                SatisFiyat1 = stok.SatisFiyat1,
                SatisFiyat2 = stok.SatisFiyat2,
                SatisFiyat3 = stok.SatisFiyat3,
                GecerliFiyat = stok.GecerliFiyat,
                OzelKod1Id = stok.OzelKod1 == null ? null : stok.OzelKod1Id,
                OzelKod2Id = stok.OzelKod2 == null ? null : stok.OzelKod2Id,
                OzelKod3Id = stok.OzelKod3 == null ? null : stok.OzelKod3Id,
                Durum = stok.Durum,
                Aciklama = stok.Aciklama
            };

            return stokSingle;
        }

        public IEnumerable<Stok> GetAll(Expression<Func<Stok, bool>> filter = null, Func<IQueryable<Stok>, IOrderedQueryable<Stok>> orderBy = null)
        {
            return _unitOfWork.GetRepository<Stok>().GetAll(filter, orderBy);
        }

        public IEnumerable<StokListDto> GetAllDto(Expression<Func<Stok, bool>> filter = null, Func<IQueryable<Stok>, IOrderedQueryable<Stok>> orderBy = null)
        {
            var result = _unitOfWork.GetRepository<Stok>().GetAll(filter, orderBy,
                a => a.StokTur,
                a => a.StokGrubu,
                a => a.StokAltGrubu,
                a => a.Marka,
                a => a.Model,
                a => a.Birim,
                a => a.OzelKod1,
                a => a.OzelKod2,
                a => a.OzelKod3).
                Select(stok => new StokListDto
                {
                    Id = stok.Id,
                    Kod = stok.Kod,
                    StokTurAdi = stok.StokTur.StokTurAdi,
                    StokAdi = stok.StokAdi,
                    StokGrubuAdi = stok.StokGrubu == null ? String.Empty : stok.StokGrubu.StokGrubuAdi,
                    StokAltGrubuAdi = stok.StokAltGrubu == null ? String.Empty : stok.StokAltGrubu.StokAltGrubuAdi,
                    MarkaAdi = stok.Marka == null ? String.Empty : stok.Marka.MarkaAdi,
                    ModelAdi = stok.Model == null ? String.Empty : stok.Model.ModelAdi,
                    BirimAdi = stok.Birim == null ? String.Empty : stok.Birim.BirimAdi,
                    Barkod = stok.Barkod,
                    AlisKdv = stok.AlisKdv,
                    SatisKdv = stok.SatisKdv,
                    AlisKdvDurum = stok.AlisKdvDurum,
                    SatisKdvDurum = stok.SatisKdvDurum,
                    AlisFiyat1 = stok.AlisFiyat1,
                    AlisFiyat2 = stok.AlisFiyat2,
                    AlisFiyat3 = stok.AlisFiyat3,
                    SatisFiyat1 = stok.SatisFiyat1,
                    SatisFiyat2 = stok.SatisFiyat2,
                    SatisFiyat3 = stok.SatisFiyat3,
                    GecerliFiyat = stok.GecerliFiyat,
                    OzelKod1Adi = stok.OzelKod1 == null ? String.Empty : stok.OzelKod1.OzelKodAdi,
                    OzelKod2Adi = stok.OzelKod2 == null ? String.Empty : stok.OzelKod2.OzelKodAdi,
                    OzelKod3Adi = stok.OzelKod3 == null ? String.Empty : stok.OzelKod3.OzelKodAdi,
                    Aciklama = stok.Aciklama
                }).ToList();

            return result;
        }

        public Stok GetById(int id)
        {
            return _unitOfWork.GetRepository<Stok>().GetById(id);
        }

        public bool Insert(Stok entity)
        {
            _unitOfWork.GetRepository<Stok>().Insert(entity);
            return true;
        }

        public bool Update(Stok entity)
        {
            _unitOfWork.GetRepository<Stok>().Update(entity);
            return true;
        }

        public string NewCode(KartTuru kartTuru, Expression<Func<Stok, string>> filter, Expression<Func<Stok, bool>> where = null)
        {
            return _unitOfWork.GetRepository<Stok>().NewCode(kartTuru, filter, where);
        }

        public void RecordHide(int id, bool hide)
        {
            _unitOfWork.GetRepository<Stok>().RecordHide(id, hide);
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }
}