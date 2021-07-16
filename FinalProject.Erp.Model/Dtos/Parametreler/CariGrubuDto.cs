namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class CariGrubuListDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string CariGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariGrubuAddDto
    {
        public string Kod { get; set; }
        public string CariGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class CariGrubuEditDto
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string CariGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class CariGrubuExportDto
    {
        public string Kod { get; set; }
        public string CariGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }
}