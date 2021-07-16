using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Base;
using FinalProject.Erp.Model.Entities.Parametreler;

namespace FinalProject.Erp.Model.Entities.Kartlar
{
    public class Kasa : BaseEntityDurum
    {
        public string KasaAdi { get; set; }
        public string Yetkili { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Aciklama { get; set; }




        public OzelKod OzelKod1 { get; set; }
    }
}