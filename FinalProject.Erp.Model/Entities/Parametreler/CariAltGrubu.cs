using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class CariAltGrubu : BaseEntityDurum
    {
        public int CariGrubuId { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }


        public CariGrubu CariGrubu { get; set; }
    }
}