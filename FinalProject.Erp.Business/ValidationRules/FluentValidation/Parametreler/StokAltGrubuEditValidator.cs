using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class StokAltGrubuEditValidator : AbstractValidator<StokAltGrubuEditDto>
    {
        public StokAltGrubuEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.StokAltGrubuAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}