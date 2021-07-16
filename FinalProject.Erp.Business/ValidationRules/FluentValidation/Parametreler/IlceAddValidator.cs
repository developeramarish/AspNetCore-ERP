using FinalProject.Erp.Model.Dtos.Parametreler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler
{
    public class IlceAddValidator : AbstractValidator<IlceAddDto>
    {
        public IlceAddValidator()
        {
            RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.IlceAdi).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}