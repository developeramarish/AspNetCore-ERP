namespace FinalProject.Erp.Model.Dtos.Parametreler
{
    public class CariAltGrubuListDto
    {
        public int Id { get; set; }
        public int CariGrubuId { get; set; }
        public string Kod { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }

    public class CariAltGrubuAddDto
    {
        public int CariGrubuId { get; set; }
        public string Kod { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class CariAltGrubuEditDto
    {
        public int Id { get; set; }
        public int CariGrubuId { get; set; }
        public string Kod { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
        public bool Durum { get; set; }
    }

    public class CariAltGrubuExportDto
    {
        public string Kod { get; set; }
        public string CariAltGrubuAdi { get; set; }
        public string Aciklama { get; set; }
    }
}