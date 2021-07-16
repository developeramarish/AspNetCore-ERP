using FinalProject.Erp.Model.Dtos.Hareketler;
using FluentValidation;

namespace FinalProject.Erp.Business.ValidationRules.FluentValidation.Hareketler
{
    public class KasaVirmanAddValidator : AbstractValidator<KasaHareketAddDto>
    {
        public KasaVirmanAddValidator()
        {
            //RuleFor(a => a.Kod).NotNull().WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.KasaId).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.TransferKasaId).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.Tarih).NotNull().WithMessage("Bu alan boş geçilemez !");
            //RuleFor(a => a.Tutar).GreaterThan(0).WithMessage("Bu alan boş geçilemez !");
        }
    }
}