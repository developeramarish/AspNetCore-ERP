using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Entities.Base;
using FinalProject.Erp.Model.Entities.Parametreler;

namespace FinalProject.Erp.Model.Entities.Kartlar
{
    public class Banka : BaseEntityDurum
    {
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string HesapNo { get; set; }
        public string IbanNo { get; set; }
        public string Yetkili { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Aciklama { get; set; }




        public OzelKod OzelKod1 { get; set; }
    }
}