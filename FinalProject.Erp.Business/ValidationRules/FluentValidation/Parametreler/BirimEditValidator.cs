using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class BirimEditValidator : AbstractValidator<BirimEditDto>
    {
        public BirimEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.BirimAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}