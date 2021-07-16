using FinalProject.Erp.Model.Dtos.Hareketler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Hareketler
{
    public class BankaTahsilatAddValidator : AbstractValidator<BankaHareketAddDto>
    {
        public BankaTahsilatAddValidator()
        {
            //RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.BankaId).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.CariId).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => (int)a.HareketTip).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.Tarih).NotNull().WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.Tutar).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
        }
    }
}