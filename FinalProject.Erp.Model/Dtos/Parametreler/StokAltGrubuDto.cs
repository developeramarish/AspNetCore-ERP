namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class StokAltGrubuListDto
    {
        public int Id { get; set; }
        public int StokGrubuId { get; set; }
        public string Kod { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class StokAltGrubuAddDto
    {
        public int StokGrubuId { get; set; }
        public string Kod { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class StokAltGrubuEditDto
    {
        public int Id { get; set; }
        public int StokGrubuId { get; set; }
        public string Kod { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }
    public class StokAltGrubuExportDto
    {
        public string Kod { get; set; }
        public string StokAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }
}