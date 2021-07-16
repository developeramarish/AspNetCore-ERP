using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class CariGrubuEditValidator : AbstractValidator<CariGrubuEditDto>
    {
        public CariGrubuEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.CariGrubuAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}