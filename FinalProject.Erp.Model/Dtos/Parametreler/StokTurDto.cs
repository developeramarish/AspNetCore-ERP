namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class StokTurListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string StokTurAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class StokTurAddDto
    {
        public string Kod { get; set; }
        public string StokTurAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; } 
    }

    public class StokTurEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string StokTurAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class StokTurExportDto
    {
        public string Kod { get; set; }
        public string StokTurAdi { get; set; }
        public string Aciklama { get; set; }
    }
}