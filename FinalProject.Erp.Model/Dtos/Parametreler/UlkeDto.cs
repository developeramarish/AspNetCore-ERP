namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class UlkeListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string UlkeAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class UlkeAddDto
    {
        public string Kod { get; set; }
        public string UlkeAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class UlkeEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string UlkeAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class UlkeExportDto
    {
        public string Kod { get; set; }
        public string UlkeAdi { get; set; }
        public string Aciklama { get; set; }
    }
}