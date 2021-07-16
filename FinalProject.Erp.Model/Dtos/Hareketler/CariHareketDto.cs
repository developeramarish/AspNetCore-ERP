using FinalProject.Erp.Common.Enums;
using System;

namespace FinalProject.Erp.Model.Dtos.Hareketler
{
    public class CariHareketListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string CariUnvani { get; set; }
        public string TransferCariUnvani { get; set; }
        public string KasaAdi { get; set; }
        public string BankaAdi { get; set; }
        public TumCariIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariHareketAddDto
    {
        public string Kod { get; set; }
        public int CariId { get; set; }
        public int? TransferCariId { get; set; }
        public int? BankaId { get; set; }
        public int? KasaId { get; set; }
        public TumCariIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariHareketEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public int CariId { get; set; }
        public int? TransferCariId { get; set; }
        public int? BankaId { get; set; }
        public int? KasaId { get; set; }
        public TumCariIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariVirmanExportDto
    {
        public string Kod { get; set; }
        public string CariUnvani { get; set; }
        public string TransferCariUnvani { get; set; }
        public TumCariIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariHareketExportDto
    {
        public string Kod { get; set; }
        public string CariUnvani { get; set; }
        public string TransferCariUnvani { get; set; }
        public string BankaAdi { get; set; }
        public string KasaAdi { get; set; }
        public TumCariIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}