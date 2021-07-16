using FinalProject.Erp.Common.Enums;
using System;

namespace FinalProject.Erp.Model.Dtos.Hareketler
{
    public class KasaHareketListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string TransferKasaAdi { get; set; }
        public string CariUnvani { get; set; }
        public string BankaAdi { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class KasaHareketAddDto
    {
        public string Kod { get; set; }
        public int KasaId { get; set; }
        public int? TransferKasaId { get; set; }
        public int? CariId { get; set; }
        public int? BankaId { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class KasaHareketEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public int KasaId { get; set; }
        public int? TransferKasaId { get; set; }
        public int? CariId { get; set; }
        public int? BankaId { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public string GC { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class KasaTahsilatExportDto
    {
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string CariUnvani { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class KasaVirmanExportDto
    {
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string TransferKasaAdi { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }

    public class KasaHareketExportDto
    {
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string TransferKasaAdi { get; set; }
        public string CariUnvani { get; set; }
        public string BankaAdi { get; set; }
        public TumKasaIslemler HareketTip { get; set; }
        public DateTime Tarih { get; set; }
        public string MakbuzNo { get; set; }
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }
    }
}