using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class CariAltGrubuAddValidator : AbstractValidator<CariAltGrubuAddDto>
    {
        public CariAltGrubuAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.CariAltGrubuAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}