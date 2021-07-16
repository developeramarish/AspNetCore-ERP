using AutoMapper;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Dtos.Identity;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Dtos.Parametreler;
using FinalProject.Erp.Model.Entities.Hareketler;
using FinalProject.Erp.Model.Entities.Identity;
using FinalProject.Erp.Model.Entities.Parametreler;

namespace FinalProject.Erp.UI.Web.Mapper.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BirimListDto, Birim>();
            CreateMap<Birim, BirimListDto>();
            CreateMap<BirimAddDto, Birim>();
            CreateMap<Birim, BirimAddDto>();
            CreateMap<BirimEditDto, Birim>();
            CreateMap<Birim, BirimEditDto>();
            CreateMap<BirimExportDto, Birim>();
            CreateMap<Birim, BirimExportDto>();

            CreateMap<CariAltGrubuListDto, CariAltGrubu>();
            CreateMap<CariAltGrubu, CariAltGrubuListDto>();
            CreateMap<CariAltGrubuAddDto, CariAltGrubu>();
            CreateMap<CariAltGrubu, CariAltGrubuAddDto>();
            CreateMap<CariAltGrubuEditDto, CariAltGrubu>();
            CreateMap<CariAltGrubu, CariAltGrubuEditDto>();
            CreateMap<CariAltGrubuExportDto, CariAltGrubu>();
            CreateMap<CariAltGrubu, CariAltGrubuExportDto>();

            CreateMap<CariGrubuListDto, CariGrubu>();
            CreateMap<CariGrubu, CariGrubuListDto>();
            CreateMap<CariGrubuAddDto, CariGrubu>();
            CreateMap<CariGrubu, CariGrubuAddDto>();
            CreateMap<CariGrubuEditDto, CariGrubu>();
            CreateMap<CariGrubu, CariGrubuEditDto>();
            CreateMap<CariGrubuExportDto, CariGrubu>();
            CreateMap<CariGrubu, CariGrubuExportDto>();

            CreateMap<IlceListDto, Ilce>();
            CreateMap<Ilce, IlceListDto>();
            CreateMap<IlceAddDto, Ilce>();
            CreateMap<Ilce, IlceAddDto>();
            CreateMap<IlceEditDto, Ilce>();
            CreateMap<Ilce, IlceEditDto>();
            CreateMap<IlceExportDto, Ilce>();
            CreateMap<Ilce, IlceExportDto>();

            CreateMap<MarkaListDto, Marka>();
            CreateMap<Marka, MarkaListDto>();
            CreateMap<MarkaAddDto, Marka>();
            CreateMap<Marka, MarkaAddDto>();
            CreateMap<MarkaEditDto, Marka>();
            CreateMap<Marka, MarkaEditDto>();
            CreateMap<MarkaExportDto, Marka>();
            CreateMap<Marka, MarkaExportDto>();

            CreateMap<ModelListDto, ModelKart>();
            CreateMap<ModelKart, ModelListDto>();
            CreateMap<ModelAddDto, ModelKart>();
            CreateMap<ModelKart, ModelAddDto>();
            CreateMap<ModelEditDto, ModelKart>();
            CreateMap<ModelKart, ModelEditDto>();
            CreateMap<ModelExportDto, ModelKart>();
            CreateMap<ModelKart, ModelExportDto>();

            CreateMap<OzelKodListDto, OzelKod>();
            CreateMap<OzelKod, OzelKodListDto>();
            CreateMap<OzelKodAddDto, OzelKod>();
            CreateMap<OzelKod, OzelKodAddDto>();
            CreateMap<OzelKodEditDto, OzelKod>();
            CreateMap<OzelKod, OzelKodEditDto>();
            CreateMap<OzelKodExportDto, OzelKod>();
            CreateMap<OzelKod, OzelKodExportDto>();

            CreateMap<SehirListDto, Sehir>();
            CreateMap<Sehir, SehirListDto>();
            CreateMap<SehirAddDto, Sehir>();
            CreateMap<Sehir, SehirAddDto>();
            CreateMap<SehirEditDto, Sehir>();
            CreateMap<Sehir, SehirEditDto>();
            CreateMap<SehirExportDto, Sehir>();
            CreateMap<Sehir, SehirExportDto>();

            CreateMap<StokAltGrubuListDto, StokAltGrubu>();
            CreateMap<StokAltGrubu, StokAltGrubuListDto>();
            CreateMap<StokAltGrubuAddDto, StokAltGrubu>();
            CreateMap<StokAltGrubu, StokAltGrubuAddDto>();
            CreateMap<StokAltGrubuEditDto, StokAltGrubu>();
            CreateMap<StokAltGrubu, StokAltGrubuEditDto>();
            CreateMap<StokAltGrubuExportDto, StokAltGrubu>();
            CreateMap<StokAltGrubu, StokAltGrubuExportDto>();

            CreateMap<StokGrubuListDto, StokGrubu>();
            CreateMap<StokGrubu, StokGrubuListDto>();
            CreateMap<StokGrubuAddDto, StokGrubu>();
            CreateMap<StokGrubu, StokGrubuAddDto>();
            CreateMap<StokGrubuEditDto, StokGrubu>();
            CreateMap<StokGrubu, StokGrubuEditDto>();
            CreateMap<StokGrubuExportDto, StokGrubu>();
            CreateMap<StokGrubu, StokGrubuExportDto>();

            CreateMap<StokTurListDto, StokTur>();
            CreateMap<StokTur, StokTurListDto>();
            CreateMap<StokTurAddDto, StokTur>();
            CreateMap<StokTur, StokTurAddDto>();
            CreateMap<StokTurEditDto, StokTur>();
            CreateMap<StokTur, StokTurEditDto>();
            CreateMap<StokTurExportDto, StokTur>();
            CreateMap<StokTur, StokTurExportDto>();

            CreateMap<UlkeListDto, Ulke>();
            CreateMap<Ulke, UlkeListDto>();
            CreateMap<UlkeAddDto, Ulke>();
            CreateMap<Ulke, UlkeAddDto>();
            CreateMap<UlkeEditDto, Ulke>();
            CreateMap<Ulke, UlkeEditDto>();
            CreateMap<UlkeExportDto, Ulke>();
            CreateMap<Ulke, UlkeExportDto>();

            //Kartlar
            CreateMap<BankaExportDto, BankaListDto>();
            CreateMap<BankaListDto, BankaExportDto>();
            CreateMap<CariExportDto, CariListDto>();
            CreateMap<CariListDto, CariExportDto>();
            CreateMap<DepoExportDto, DepoListDto>();
            CreateMap<DepoListDto, DepoExportDto>();
            CreateMap<KasaExportDto, KasaListDto>();
            CreateMap<KasaListDto, KasaExportDto>();
            CreateMap<StokExportDto, StokListDto>();
            CreateMap<StokListDto, StokExportDto>();

            //Identity
            CreateMap<AppUser, AppUserEditDto>();
            CreateMap<AppUserEditDto, AppUser>();

            //Banka Hareket
            CreateMap<BankaHareket, BankaHareketListDto>();
            CreateMap<BankaHareketListDto, BankaHareket>();
            CreateMap<BankaHareketListDto, BankaTahsilatExportDto>();
            CreateMap<BankaTahsilatExportDto, BankaHareketListDto>();
            CreateMap<BankaHareketListDto, BankaKasaExportDto>();
            CreateMap<BankaKasaExportDto, BankaHareketListDto>();

            //Kasa Hareket
            CreateMap<KasaHareket, KasaHareketListDto>();
            CreateMap<KasaHareketListDto, KasaHareket>();
            CreateMap<KasaHareketListDto, KasaTahsilatExportDto>();
            CreateMap<KasaTahsilatExportDto, KasaHareketListDto>();
            CreateMap<KasaHareketListDto, KasaVirmanExportDto>();
            CreateMap<KasaVirmanExportDto, KasaHareketListDto>();

            //Cari Hareket
            CreateMap<CariHareket, CariHareketListDto>();
            CreateMap<CariHareketListDto, CariHareket>();
            CreateMap<CariHareketListDto, CariVirmanExportDto>();
            CreateMap<CariVirmanExportDto, CariHareketListDto>();
        }
    }
}