using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Base;
using FinalProject.Erp.Model.Entities.Kartlar;
using System;

namespace FinalProject.Erp.Model.Entities.Hareketler
{
    public class BankaHareket : BaseEntity
    {
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




        public Banka Banka { get; set; }
        public Banka TransferBanka { get; set; }
        public Cari Cari { get; set; }
        public Kasa Kasa { get; set; }
    }
}