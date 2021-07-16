namespace FinalProject.Erp.Model.Dtos.Identity
{
    public class AppUserAddDto
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class AppUserEditDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
    }

    public class AppUserSignDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}