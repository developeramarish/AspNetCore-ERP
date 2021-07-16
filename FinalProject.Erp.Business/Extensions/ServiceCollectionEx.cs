using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Hareketler;
using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Business.Logger.Base;
using FinalProject.Erp.Business.Logger.NLog;
using FinalProject.Erp.Business.Service.Dosyalar;
using FinalProject.Erp.Business.Service.Hareketler;
using FinalProject.Erp.Business.Service.Kartlar;
using FinalProject.Erp.Business.Service.Parametreler;
using FinalProject.Erp.Business.ValidationRules.FluentValidation.Hareketler;
using FinalProject.Erp.Business.ValidationRules.FluentValidation.Identity;
using FinalProject.Erp.Business.ValidationRules.FluentValidation.Kartlar;
using FinalProject.Erp.Business.ValidationRules.FluentValidation.Parametreler;
using FinalProject.Erp.Core.Abstract.UnitOfWork;
using FinalProject.Erp.Core.Concrete.EfCore.UnitOfWork;
using FinalProject.Erp.DataAccess.Abstract.Hareketler;
using FinalProject.Erp.DataAccess.Abstract.Kartlar;
using FinalProject.Erp.DataAccess.Abstract.Parametreler;
using FinalProject.Erp.DataAccess.Concrete.EfCore.Context;
using FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Hareketler;
using FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Kartlar;
using FinalProject.Erp.DataAccess.Concrete.EfCore.DataAccess.Parametreler;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Dtos.Identity;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Dtos.Parametreler;
using FinalProject.Erp.Model.Entities.Identity;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinalProject.Erp.Business.Extensions
{
    public static class ServiceCollectionEx
    {
        public static void AddScopedConfig(this IServiceCollection services)
        {
            services.AddScoped<ICariGrubuService, CariGrubuService>();
            services.AddScoped<ICariAltGrubuService, CariAltGrubuService>();
            services.AddScoped<IOzelKodService, OzelKodService>();
            services.AddScoped<IUlkeService, UlkeService>();
            services.AddScoped<ISehirService, SehirService>();
            services.AddScoped<IIlceService, IlceService>();
            services.AddScoped<IStokTurService, StokTurService>();
            services.AddScoped<IBirimService, BirimService>();
            services.AddScoped<IStokGrubuService, StokGrubuService>();
            services.AddScoped<IStokAltGrubuService, StokAltGrubuService>();
            services.AddScoped<IMarkaService, MarkaService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IBankaService, BankaService>();
            services.AddScoped<IKasaService, KasaService>();
            services.AddScoped<ICariService, CariService>();
            services.AddScoped<IStokService, StokService>();
            services.AddScoped<IDepoService, DepoService>();
            services.AddScoped<IDosyaService, DosyaService>();
            services.AddScoped<IBankaHareketService, BankaHareketService>();
            services.AddScoped<ICariHareketService, CariHareketService>();
            services.AddScoped<IKasaHareketService, KasaHareketService>();
            services.AddScoped<ICariHareketService, CariHareketService>();
            services.AddScoped<IDovizKurService, DovizKurService>();


            services.AddScoped<ICariGrubuDal, EfCariGrubuDal>();
            services.AddScoped<ICariAltGrubuDal, EfCariAltGrubuDal>();
            services.AddScoped<IOzelKodDal, EfOzelKodDal>();
            services.AddScoped<IUlkeDal, EfUlkeDal>();
            services.AddScoped<IIlceDal, EfIlceDal>();
            services.AddScoped<IStokTurDal, EfStokTurDal>();
            services.AddScoped<IBirimDal, EfBirimDal>();
            services.AddScoped<IStokGrubuDal, EfStokGrubuDal>();
            services.AddScoped<IStokAltGrubuDal, EfStokAltGrubuDal>();
            services.AddScoped<IMarkaDal, EfMarkaDal>();
            services.AddScoped<IModelDal, EfModelDal>();
            services.AddScoped<IBankaDal, EfBankaDal>();
            services.AddScoped<IKasaDal, EfKasaDal>();
            services.AddScoped<ICariDal, EfCariDal>();
            services.AddScoped<IStokDal, EfStokDal>();
            services.AddScoped<IDepoDal, EfDepoDal>();
            services.AddScoped<IBankaHareketDal, BankaHareketDal>();
            services.AddScoped<ICariHareketDal, CariHareketDal>();
            services.AddScoped<IKasaHareketDal, KasaHareketDal>();
            services.AddScoped<ICariHareketDal, CariHareketDal>();
            services.AddScoped<IDovizKurDal, DovizKurDal>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }

        public static void AddIdentityConfig(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ErpContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "BilgeAdamERPCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddValidationConfig(this IServiceCollection services)
        {
            services.AddTransient<IValidator<BirimAddDto>, BirimAddValidator>();
            services.AddTransient<IValidator<BirimEditDto>, BirimEditValidator>();
            services.AddTransient<IValidator<CariAltGrubuAddDto>, CariAltGrubuAddValidator>();
            services.AddTransient<IValidator<CariAltGrubuEditDto>, CariAltGrubuEditValidator>();
            services.AddTransient<IValidator<CariGrubuAddDto>, CariGrubuAddValidator>();
            services.AddTransient<IValidator<CariGrubuEditDto>, CariGrubuEditValidator>();
            services.AddTransient<IValidator<IlceAddDto>, IlceAddValidator>();
            services.AddTransient<IValidator<IlceEditDto>, IlceEditValidator>();
            services.AddTransient<IValidator<MarkaAddDto>, MarkaAddValidator>();
            services.AddTransient<IValidator<MarkaEditDto>, MarkaEditValidator>();
            services.AddTransient<IValidator<ModelAddDto>, ModelAddValidator>();
            services.AddTransient<IValidator<ModelEditDto>, ModelEditValidator>();
            services.AddTransient<IValidator<OzelKodAddDto>, OzelKodAddValidator>();
            services.AddTransient<IValidator<OzelKodEditDto>, OzelKodEditValidator>();
            services.AddTransient<IValidator<SehirAddDto>, SehirAddValidator>();
            services.AddTransient<IValidator<SehirEditDto>, SehirEditValidator>();
            services.AddTransient<IValidator<StokAltGrubuAddDto>, StokAltGrubuAddValidator>();
            services.AddTransient<IValidator<StokAltGrubuEditDto>, StokAltGrubuEditValidator>();
            services.AddTransient<IValidator<StokGrubuAddDto>, StokGrubuAddValidator>();
            services.AddTransient<IValidator<StokGrubuEditDto>, StokGrubuEditValidator>();
            services.AddTransient<IValidator<StokTurAddDto>, StokTurAddValidator>();
            services.AddTransient<IValidator<StokTurEditDto>, StokTurEditValidator>();
            services.AddTransient<IValidator<UlkeAddDto>, UlkeAddValidator>();
            services.AddTransient<IValidator<UlkeEditDto>, UlkeEditValidator>();
            services.AddTransient<IValidator<BankaAddDto>, BankaAddValidator>();
            services.AddTransient<IValidator<BankaEditDto>, BankaEditValidator>();
            services.AddTransient<IValidator<CariAddDto>, CariAddValidator>();
            services.AddTransient<IValidator<CariEditDto>, CariEditValidator>();
            services.AddTransient<IValidator<DepoAddDto>, DepoAddValidator>();
            services.AddTransient<IValidator<DepoEditDto>, DepoEditValidator>();
            services.AddTransient<IValidator<KasaAddDto>, KasaAddValidator>();
            services.AddTransient<IValidator<KasaEditDto>, KasaEditValidator>();
            services.AddTransient<IValidator<StokAddDto>, StokAddValidator>();
            services.AddTransient<IValidator<StokEditDto>, StokEditValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignDto>, AppUserSignValidator>();

            //
            //services.AddTransient<IValidator<BankaHareketAddDto>, BankaTahsilatAddValidator>();
            //services.AddTransient<IValidator<BankaHareketEditDto>, BankaTahsilatEditValidator>();
            //services.AddTransient<IValidator<KasaHareketAddDto>, NakitTahsilatAddValidator>();
            //services.AddTransient<IValidator<KasaHareketEditDto>, NakitTahsilatEditValidator>();
            //services.AddTransient<IValidator<CariHareketAddDto>, CariVirmanAddValidator>();
            //services.AddTransient<IValidator<CariHareketEditDto>, CariVirmanEditValidator>();
        }
    }
}