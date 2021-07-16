using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class KasaEditValidator : AbstractValidator<KasaEditDto>
    {
        public KasaEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.KasaAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}