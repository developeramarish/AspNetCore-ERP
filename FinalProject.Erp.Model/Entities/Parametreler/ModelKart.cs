using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class ModelKart : BaseEntityDurum
    {
        public int MarkaId { get; set; }
        public string ModelAdi { get; set; }
        public string Aciklama { get; set; }







        public Marka Marka { get; set; }
    }
}