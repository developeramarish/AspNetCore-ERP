using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Base;
using FinalProject.Erp.Model.Entities.Parametreler;
using System;

namespace FinalProject.Erp.Model.Entities.Kartlar
{
    public class Stok : BaseEntityDurum
    {
        public int StokTurId { get; set; }
        public string StokAdi { get; set; }
        public int? StokGrubuId { get; set; }
        public int? StokAltGrubuId { get; set; }
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }
        public int BirimId { get; set; }
        public string Barkod { get; set; }
        public Int16 AlisKdv { get; set; }
        public Int16 SatisKdv { get; set; }
        public KdvDurum AlisKdvDurum { get; set; }
        public KdvDurum SatisKdvDurum { get; set; }
        public decimal AlisFiyat1 { get; set; }
        public decimal AlisFiyat2 { get; set; }
        public decimal AlisFiyat3 { get; set; }
        public decimal SatisFiyat1 { get; set; }
        public decimal SatisFiyat2 { get; set; }
        public decimal SatisFiyat3 { get; set; }
        public FiyatGrubu GecerliFiyat { get; set; }
        public int? OzelKod1Id { get; set; }
        public int? OzelKod2Id { get; set; }
        public int? OzelKod3Id { get; set; }
        public string Aciklama { get; set; }




        public StokTur StokTur { get; set; }
        public StokGrubu StokGrubu { get; set; }
        public StokAltGrubu StokAltGrubu { get; set; }
        public Marka Marka { get; set; }
        public ModelKart Model { get; set; }
        public Birim Birim { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
        public OzelKod OzelKod3 { get; set; }
    }
}