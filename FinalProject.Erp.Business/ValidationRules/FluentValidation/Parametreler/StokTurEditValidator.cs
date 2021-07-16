using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class StokTurEditValidator : AbstractValidator<StokTurEditDto>
    {
        public StokTurEditValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.StokTurAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}