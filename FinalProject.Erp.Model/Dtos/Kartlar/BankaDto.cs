namespace FinalProject.Erp.Model.Dtos.Kartlar
{
    public class BankaListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string HesapNo { get; set; }
        public string IbanNo { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public string OzelKod1Adi { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Aciklama { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class BankaAddDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string HesapNo { get; set; }
        public string IbanNo { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class BankaEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string HesapNo { get; set; }
        public string IbanNo { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Gsm { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class BankaExportDto
    {
        public string Kod { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSube { get; set; }
        public string Yetkili { get; set; }
        public string OzelKod1Adi { get; set; }
        public decimal Bakiye { get; set; }
    }
}