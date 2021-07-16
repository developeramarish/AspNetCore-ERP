using FinalProject.Erp.Core.Abstract.Base;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Erp.Model.Entities.Identity
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Gsm { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
    }
}