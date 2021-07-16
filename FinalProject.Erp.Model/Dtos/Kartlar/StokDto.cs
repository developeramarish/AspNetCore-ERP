using FinalProject.Erp.Common.Enums;
using System;

namespace FinalProject.Erp.Model.Dtos.Kartlar
{
    public class StokListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string StokAdi { get; set; }
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
        public string Aciklama { get; set; }
        public string StokTurAdi { get; set; }
        public string StokGrubuAdi { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string MarkaAdi { get; set; }
        public string ModelAdi { get; set; }
        public string BirimAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public decimal MevcutStok { get; set; }
    }

    public class StokAddDto
    {
        public string Kod { get; set; }
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
        public bool Durum { get; set; }
    }

    public class StokEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
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
        public bool Durum { get; set; }
        public decimal MevcutStok { get; set; }
    }

    public class StokExportDto
    {
        public string Kod { get; set; }
        public string StokAdi { get; set; }
        public string Barkod { get; set; }
        public decimal SatisFiyat1 { get; set; }
        public string OzelKod1Adi { get; set; }
        public decimal MevcutStok { get; set; }
    }
}