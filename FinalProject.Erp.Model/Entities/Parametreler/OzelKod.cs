using FinalProject.Erp.Model.Entities.Base;

namespace FinalProject.Erp.Model.Entities.Parametreler
{
    public class OzelKod : BaseEntityDurum
    {
        public int OzelKodTip { get; set; }
        public int OzelKodSira { get; set; }
        public string OzelKodAdi { get; set; }
        public string Aciklama { get; set; }
    }
}