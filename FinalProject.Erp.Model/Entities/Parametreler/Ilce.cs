using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class Ilce : BaseEntityDurum
    {
        public int SehirId { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }



        public Sehir Sehir { get; set; }
    }
}