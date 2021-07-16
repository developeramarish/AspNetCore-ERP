namespace FinalProject.Erp.Model.Dtos.Kartlar
{
    public class DepoListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string DepoAdi { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
    }

    public class DepoAddDto
    {
        public string Kod { get; set; }
        public string DepoAdi { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class DepoEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string DepoAdi { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class DepoExportDto
    {
        public string Kod { get; set; }
        public string DepoAdi { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }
    }
}