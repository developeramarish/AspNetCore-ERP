using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class UlkeAddValidator : AbstractValidator<UlkeAddDto>
    {
        public UlkeAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.UlkeAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}