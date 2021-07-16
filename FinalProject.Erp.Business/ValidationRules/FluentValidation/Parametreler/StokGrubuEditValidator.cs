using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class StokGrubuEditValidator : AbstractValidator<StokGrubuEditDto>
    {
        public StokGrubuEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.StokGrubuAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}