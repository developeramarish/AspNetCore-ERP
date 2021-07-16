namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class StokGrubuListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string StokGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class StokGrubuAddDto
    {
        public string Kod { get; set; }
        public string StokGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class StokGrubuEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string StokGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class StokGrubuExportDto
    {
        public string Kod { get; set; }
        public string StokGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }
}