using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class BankaAddValidator : AbstractValidator<BankaAddDto>
    {
        public BankaAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.BankaAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}