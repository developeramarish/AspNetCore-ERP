using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class MarkaAddValidator : AbstractValidator<MarkaAddDto>
    {
        public MarkaAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.MarkaAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}