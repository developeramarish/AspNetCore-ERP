using FinalProject.Erp.Core.Abstract.Base;
using System;

namespace FinalProject.Erp.Model.Entities.Base
{
    public abstract class BaseEntity : BaseKod, IEntity
    {
        public bool Silindi { get; set; } = false;
        //Veri işleme bilgileri
        public DateTime? EklemeTarih { get; set; }
        public DateTime? DuzenlemeTarih { get; set; }
        public DateTime? SilinmeTarih { get; set; }
        public DateTime? GeriAlmaTarih { get; set; }
        public int? EkleyenId { get; set; }
        public int? DuzenleyenId { get; set; }
        public int? SilenId { get; set; }
        public int? GeriAlanId { get; set; }
    }
}