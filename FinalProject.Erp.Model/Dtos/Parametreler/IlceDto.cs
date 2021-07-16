namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class IlceListDto
    {
        public int Id { get; set; }
        public int SehirId { get; set; }
        public string Kod { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class IlceAddDto
    {
        public int SehirId { get; set; }
        public string Kod { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class IlceEditDto
    {
        public int Id { get; set; }
        public int SehirId { get; set; }
        public string Kod { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class IlceExportDto
    {
        public string Kod { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}