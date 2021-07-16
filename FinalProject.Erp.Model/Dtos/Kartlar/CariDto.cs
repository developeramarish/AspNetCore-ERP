using FinalProject.Erp.Common.Enums;

namespace FinalProject.Erp.Model.Dtos.Kartlar
{
    public class CariListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public CariTipi CariTipi { get; set; }
        public string CariUnvani { get; set; }
        public string Yetkili { get; set; }
        public string CariGrubuAdi { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public FiyatGrubu FiyatGrubu { get; set; }
        public string VergiDaire { get; set; }
        public string VergiNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string Adres { get; set; }
        public string UlkeAdi { get; set; }
        public string SehirAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class CariAddDto
    {
        public string Kod { get; set; }
        public CariTipi CariTipi { get; set; }
        public string CariUnvani { get; set; }
        public string Yetkili { get; set; }
        public int? CariGrubuId { get; set; }
        public int? CariAltGrubuId { get; set; }
        public FiyatGrubu FiyatGrubu { get; set; }
        public string VergiDaire { get; set; }
        public string VergiNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string Adres { get; set; }
        public int? UlkeId { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int? OzelKod1Id { get; set; }
        public int? OzelKod2Id { get; set; }
        public int? OzelKod3Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class CariEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public CariTipi CariTipi { get; set; }
        public string CariUnvani { get; set; }
        public string Yetkili { get; set; }
        public int? CariGrubuId { get; set; }
        public int? CariAltGrubuId { get; set; }
        public FiyatGrubu FiyatGrubu { get; set; }
        public string VergiDaire { get; set; }
        public string VergiNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string Adres { get; set; }
        public int? UlkeId { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int? OzelKod1Id { get; set; }
        public int? OzelKod2Id { get; set; }
        public int? OzelKod3Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class CariExportDto
    {
        public string Kod { get; set; }
        public string CariUnvani { get; set; }
        public CariTipi CariTipi { get; set; }
        public string Yetkili { get; set; }
        public string OzelKod1Adi { get; set; }
        public decimal Bakiye { get; set; }
    }
}