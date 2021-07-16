namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class BirimListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string BirimAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class BirimAddDto
    {
        public string Kod { get; set; }
        public string BirimAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class BirimEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string BirimAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class BirimExportDto
    {
        public string Kod { get; set; }
        public string BirimAdi { get; set; }
        public string Aciklama { get; set; }
    }
}