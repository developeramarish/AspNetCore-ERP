using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class StokAltGrubu : BaseEntityDurum
    {
        public int StokGrubuId { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }



        public StokGrubu StokGrubu { get; set; }
    }
}