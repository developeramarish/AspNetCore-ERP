namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class MarkaListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class MarkaAddDto
    {
        public string Kod { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class MarkaEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class MarkaExportDto
    {
        public string Kod { get; set; }
        public string MarkaAdi { get; set; }
        public string Aciklama { get; set; }
    }
}