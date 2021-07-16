using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class DepoEditValidator : AbstractValidator<DepoEditDto>
    {
        public DepoEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.DepoAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}