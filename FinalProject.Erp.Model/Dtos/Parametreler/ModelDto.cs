namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class ModelListDto
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public string Kod { get; set; }
        public string ModelAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class ModelAddDto
    {
        public int MarkaId { get; set; }
        public string Kod { get; set; }
        public string ModelAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class ModelEditDto
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public string Kod { get; set; }
        public string ModelAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class ModelExportDto
    {
        public string Kod { get; set; }
        public string ModelAdi { get; set; }
        public string Aciklama { get; set; }
    }
}