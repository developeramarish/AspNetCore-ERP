using FinalProject.Erp.Business.Abstract.Hareketler;
using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IDovizKurService _dovizKurService;
        private readonly IBankaHareketService _bankaHareketService;
        private readonly IKasaHareketService _kasaHareketService;
        private readonly ICariHareketService _cariHareketService;

        public GeneralController(
            IDovizKurService dovizKurService, 
            IBankaHareketService bankaHareketService,
            IKasaHareketService kasaHareketService,
            ICariHareketService cariHareketService)
        {
            _dovizKurService = dovizKurService;
            _bankaHareketService = bankaHareketService;
            _kasaHareketService = kasaHareketService;
            _cariHareketService = cariHareketService;
        }

        void DovizFillValues()
        {
             _dovizKurService.GetAllCurrenciesTodaysExchangeRates();
            try
            {
                DovizKur dovizKur = _dovizKurService.GetAll(a => a.DovizKodu == "USD").ToList().FirstOrDefault();
                ViewBag.Dolar = dovizKur.DovizAlis;

                dovizKur = _dovizKurService.GetAll(a => a.DovizKodu == "EUR").ToList().FirstOrDefault();
                ViewBag.Euro = dovizKur.DovizAlis;

                dovizKur = _dovizKurService.GetAll(a => a.DovizKodu == "GBP").ToList().FirstOrDefault();
                ViewBag.Pound = dovizKur.DovizAlis;

                dovizKur = _dovizKurService.GetAll(a => a.DovizKodu == "JPY").ToList().FirstOrDefault();
                ViewBag.Yen = dovizKur.DovizAlis;
            }
            catch (System.Exception)
            {
                ViewBag.Dolar = 0;
                ViewBag.Euro = 0;
                ViewBag.Pound = 0;
                ViewBag.Yen = 0;
            }

        }

        void StatisticsFillValues()
        {
            decimal toplam = 0;
            List<BankaHareketListDto> bankaHareketLists = _bankaHareketService.GetAllDto(a => a.Silindi == false && a.GC == "G").ToList();
            foreach (BankaHareketListDto item in bankaHareketLists)
            {
                toplam += item.Tutar;
            }

            bankaHareketLists = _bankaHareketService.GetAllDto(a => a.Silindi == false && a.GC == "C").ToList();
            foreach (BankaHareketListDto item in bankaHareketLists)
            {
                toplam -= item.Tutar;
            }
            ViewBag.Banka = toplam.ToString("N2");

            toplam = 0;
            List<KasaHareketListDto> kasaHareketLists = _kasaHareketService.GetAllDto(a => a.Silindi == false && a.GC == "G").ToList();
            foreach (KasaHareketListDto item in kasaHareketLists)
            {
                toplam += item.Tutar;
            }

            kasaHareketLists = _kasaHareketService.GetAllDto(a => a.Silindi == false && a.GC == "C").ToList();
            foreach (KasaHareketListDto item in kasaHareketLists)
            {
                toplam -= item.Tutar;
            }
            ViewBag.Kasa = toplam.ToString("N2"); ;

            toplam = 0;
            List<CariHareketListDto> cariHareketLists = _cariHareketService.GetAllDto(a => a.Silindi == false && a.GC == "G").ToList();
            foreach (CariHareketListDto item in cariHareketLists)
            {
                toplam += item.Tutar;
            }

            cariHareketLists = _cariHareketService.GetAllDto(a => a.Silindi == false && a.GC == "C").ToList();
            foreach (CariHareketListDto item in cariHareketLists)
            {
                toplam -= item.Tutar;
            }
            if (toplam >= 0)
            {
                ViewBag.Alacak = 0;
                ViewBag.Borc = toplam.ToString("N2");
            }
            else
            {
                ViewBag.Alacak = ((-1) * toplam).ToString("N2");
                ViewBag.Borc = 0;
            }
        }

        public IActionResult Index()
        {
            DovizFillValues();
            StatisticsFillValues();

            TempData["Active-In"] = "genelBilgiler";
            TempData["Active"] = "genelOzet";

            return View();
        }
    }
}