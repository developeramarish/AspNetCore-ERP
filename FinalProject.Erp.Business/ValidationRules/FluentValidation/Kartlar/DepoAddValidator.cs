using FinalProject.Erp.Model.Dtos.Kartlar;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar
{
    public class DepoAddValidator : AbstractValidator<DepoAddDto>
    {
        public DepoAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.DepoAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}