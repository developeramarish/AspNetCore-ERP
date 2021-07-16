using FinalProject.Erp.Model.Dtos.Identity;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Identity
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(a => a.Adi).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Soyadi).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Gsm).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Email).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.UserName).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.Password).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.ConfirmPassword).NotNull().WithMessage("Bu alan boş geçilemez !");
            RuleFor(a => a.ConfirmPassword).Equal(a => a.Password).WithMessage("Girdiğiniz şifreler eşleşmemektedir !");
        }
    }
}