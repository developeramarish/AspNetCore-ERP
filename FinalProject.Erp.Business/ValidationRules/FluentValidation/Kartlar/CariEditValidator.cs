using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class CariEditValidator : AbstractValidator<CariEditDto>
    {
        public CariEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.CariUnvani).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.CariTipi).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => (int)a.FiyatGrubu).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
        }
    }
}