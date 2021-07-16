using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Base;
using FinalProject.Erp.Model.Entities.Parametreler;

namespace FinalProject.Erp.Model.Entities.Kartlar
{
    public class Cari : BaseEntityDurum
    {
        public CariTipi CariTipi { get; set; }
        public string CariUnvani { get; set; }
        public string Yetkili { get; set; }
        public int? CariGrubuId { get; set; }
        public int? CariAltGrubuId { get; set; }
        public FiyatGrubu FiyatGrubu { get; set; }
        public string VergiDaire { get; set; }
        public string VergiNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string Adres { get; set; }
        public int? UlkeId { get; set; }
        public int? SehirId { get; set; }
        public int? IlceId { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public int? OzelKod1Id { get; set; }
        public int? OzelKod2Id { get; set; }
        public int? OzelKod3Id { get; set; }
        public string Aciklama { get; set; }







        public CariGrubu CariGrubu { get; set; }
        public CariAltGrubu CariAltGrubu { get; set; }
        public Ulke Ulke { get; set; }
        public Sehir Sehir { get; set; }
        public Ilce Ilce { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
        public OzelKod OzelKod3 { get; set; }
    }
}