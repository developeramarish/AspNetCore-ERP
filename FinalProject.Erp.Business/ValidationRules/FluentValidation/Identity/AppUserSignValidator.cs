using FinalProject.Erp.Model.Dtos.Identity;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Identity
{
    public class AppUserSignValidator : AbstractValidator<AppUserSignDto>
    {
        public AppUserSignValidator()
        {
            RuleFor(a => a.UserName).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Password).NotNull().WithMessage("Bu alan boş geçilemez !");
        }
    }
}