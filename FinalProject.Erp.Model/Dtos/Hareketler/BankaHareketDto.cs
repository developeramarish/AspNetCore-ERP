using FinalProject.Erp.Common.Enums;
using System;

namespace FinalProject.Erp.Model.Dtos.Hareketler
{
    public class BankaHareketListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string TransferBankaAdi { get; set; }
        public string CariUnvani { get; set; }
        public string KasaAdi { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaHareketAddDto
    {
        public string Kod { get; set; }
        public int BankaId { get; set; }
        public int? TransferBankaId { get; set; }
        public int? CariId { get; set; }
        public int? KasaId { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaHareketEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public int BankaId { get; set; }
        public int? TransferBankaId { get; set; }
        public int? CariId { get; set; }
        public int? KasaId { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaTahsilatExportDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string CariUnvani { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaVirmanExportDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string TransferBankaAdi { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaKasaExportDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string KasaAdi { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class BankaHareketExportDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string TransferBankaAdi { get; set; }
        public string CariUnvani { get; set; }
        public string KasaAdi { get; set; }
        public TumBankaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}