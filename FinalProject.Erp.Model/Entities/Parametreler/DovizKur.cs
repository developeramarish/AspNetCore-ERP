using FinalProject.Erp.Core.Abstract.Base;
using FinalProject.Erp.Model.Entities.Base;
using System;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class DovizKur : BaseId, IEntity
    {
        public DateTime Tarih { get; set; }
        public string DovizKodu { get; set; }
        public string DovizCinsi { get; set; }
        public Int16 Birim { get; set; }
        public decimal DovizAlis { get; set; }
        public decimal DovizSatis { get; set; }
        public decimal EfektifAlis { get; set; }
        public decimal EfektifSatis { get; set; }
    }
}