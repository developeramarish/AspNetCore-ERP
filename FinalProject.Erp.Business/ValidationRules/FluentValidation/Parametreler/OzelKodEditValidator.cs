using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class OzelKodEditValidator : AbstractValidator<OzelKodEditDto>
    {
        public OzelKodEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.OzelKodAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}