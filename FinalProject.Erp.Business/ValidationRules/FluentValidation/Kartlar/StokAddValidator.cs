using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class StokAddValidator : AbstractValidator<StokAddDto>
    {
        public StokAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.StokAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Barkod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.StokTurId).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.AlisKdv).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.SatisKdv).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.AlisKdvDurum).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.SatisKdvDurum).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.GecerliFiyat).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
        }
    }
}