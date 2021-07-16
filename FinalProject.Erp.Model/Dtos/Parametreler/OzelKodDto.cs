namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class OzelKodListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string OzelKodAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class OzelKodAddDto
    {
        public string Kod { get; set; }
        public string OzelKodAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class OzelKodEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string OzelKodAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class OzelKodExportDto
    {
        public string Kod { get; set; }
        public string OzelKodAdi { get; set; }
        public string Aciklama { get; set; }
    }
}