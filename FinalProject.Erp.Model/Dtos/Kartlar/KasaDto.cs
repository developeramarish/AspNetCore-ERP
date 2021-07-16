namespace FinalProject.Erp.Model.Dtos.Kartlar
{
    public class KasaListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string Yetkili { get; set; }
        public string OzelKod1Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class KasaAddDto
    {
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string Yetkili { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class KasaEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string Yetkili { get; set; }
        public int? OzelKod1Id { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
        public decimal Bakiye { get; set; }
    }

    public class KasaExportDto
    {
        public string Kod { get; set; }
        public string KasaAdi { get; set; }
        public string Yetkili { get; set; }
        public string OzelKod1Adi { get; set; }
        public string Aciklama { get; set; }
        public decimal Bakiye { get; set; }
    }
}