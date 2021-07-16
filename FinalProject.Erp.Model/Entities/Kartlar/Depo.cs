using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Kartlar
{
    public class Depo : BaseEntityDurum
    {
        public string DepoAdi { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
    }
}