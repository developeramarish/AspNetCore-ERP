using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class SehirAddValidator : AbstractValidator<SehirAddDto>
    {
        public SehirAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.SehirAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}