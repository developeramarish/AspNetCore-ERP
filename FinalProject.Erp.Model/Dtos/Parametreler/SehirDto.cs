namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class SehirListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string SehirAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class SehirAddDto
    {
        public string Kod { get; set; }
        public string SehirAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class SehirEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string SehirAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class SehirExportDto
    {
        public string Kod { get; set; }
        public string SehirAdi { get; set; }
        public string Aciklama { get; set; }
    }
}