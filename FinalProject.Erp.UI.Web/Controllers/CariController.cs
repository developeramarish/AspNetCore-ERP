using AutoMapper;
using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class CariController : Controller
    {
        private readonly ICariService _cariService;
        private readonly IOzelKodService _ozelKodService1;
        private readonly IOzelKodService _ozelKodService2;
        private readonly IOzelKodService _ozelKodService3;
        private readonly ICariGrubuService _cariGrubuService;
        private readonly ICariAltGrubuService _cariAltGrubuService;
        private readonly IUlkeService _ulkeService;
        private readonly ISehirService _sehirService;
        private readonly IIlceService _ilceService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private static bool _durum;

        public CariController(ICariService cariService,
            IOzelKodService ozelKodService1,
            IOzelKodService ozelKodService2,
            IOzelKodService ozelKodService3,
            ICariGrubuService cariGrubuService,
            ICariAltGrubuService cariAltGrubuService,
            IUlkeService ulkeService,
            ISehirService sehirService,
            IIlceService ilceService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _cariService = cariService;
            _ozelKodService1 = ozelKodService1;
            _ozelKodService2 = ozelKodService2;
            _ozelKodService3 = ozelKodService3;
            _cariGrubuService = cariGrubuService;
            _cariAltGrubuService = cariAltGrubuService;
            _ulkeService = ulkeService;
            _sehirService = sehirService;
            _ilceService = ilceService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void CariFillParameter()
        {
            ViewBag.CariOzelKodlar1 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Cari, OzelKodSira.Sira1).ToList(), "Id", "OzelKodAdi");
            ViewBag.CariOzelKodlar2 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Cari, OzelKodSira.Sira2).ToList(), "Id", "OzelKodAdi");
            ViewBag.CariOzelKodlar3 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Cari, OzelKodSira.Sira3).ToList(), "Id", "OzelKodAdi");
            ViewBag.CariGruplar = new SelectList(_cariGrubuService.GetAllByActiveCars(true).ToList(), "Id", "CariGrubuAdi");
            ViewBag.CariUlkeler = new SelectList(_ulkeService.GetAllByActiveCars(true).ToList(), "Id", "UlkeAdi");
            ViewBag.CariSehirler = new SelectList(_sehirService.GetAllByActiveCars(true).ToList(), "Id", "SehirAdi");
            //
            ViewBag.CariAltGruplar = new SelectList(_cariAltGrubuService.GetAll(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "CariAltGrubuAdi");
            ViewBag.CariIlceler = new SelectList(_ilceService.GetAll(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "IlceAdi");
        }

        List<CariListDto> CallListByCards()
        {
            return _cariService.GetAllDto(a => a.Durum == _durum && a.Silindi == false).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariKart";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariKart";

            CariFillParameter();

            return View(new CariAddDto
            {
                Kod = _cariService.NewCode(KartTuru.Cari, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(CariAddDto model)
        {
            if (ModelState.IsValid)
            {
                _cariService.Insert(new Cari
                {
                    Kod = model.Kod,
                    CariTipi = model.CariTipi,
                    CariUnvani = model.CariUnvani,
                    Yetkili = model.Yetkili,
                    CariGrubuId = model.CariGrubuId,
                    CariAltGrubuId = model.CariAltGrubuId,
                    FiyatGrubu = model.FiyatGrubu,
                    VergiDaire = model.VergiDaire,
                    VergiNo = model.VergiNo,
                    TcKimlikNo = model.TcKimlikNo,
                    Adres = model.Adres,
                    UlkeId = model.UlkeId,
                    SehirId = model.SehirId,
                    IlceId = model.IlceId,
                    Telefon = model.Telefon,
                    Faks = model.Faks,
                    Gsm = model.Gsm,
                    Email = model.Email,
                    Web = model.Web,
                    OzelKod1Id = model.OzelKod1Id,
                    OzelKod2Id = model.OzelKod2Id,
                    OzelKod3Id = model.OzelKod3Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariKart";

            CariFillParameter();

            CariEditDto model = _cariService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CariEditDto model)
        {
            if (ModelState.IsValid)
            {
                _cariService.Update(new Cari
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    CariTipi = model.CariTipi,
                    CariUnvani = model.CariUnvani,
                    Yetkili = model.Yetkili,
                    CariGrubuId = model.CariGrubuId,
                    CariAltGrubuId = model.CariAltGrubuId,
                    FiyatGrubu = model.FiyatGrubu,
                    VergiDaire = model.VergiDaire,
                    VergiNo = model.VergiNo,
                    TcKimlikNo = model.TcKimlikNo,
                    Adres = model.Adres,
                    UlkeId = model.UlkeId,
                    SehirId = model.SehirId,
                    IlceId = model.IlceId,
                    Telefon = model.Telefon,
                    Faks = model.Faks,
                    Gsm = model.Gsm,
                    Email = model.Email,
                    Web = model.Web,
                    OzelKod1Id = model.OzelKod1Id,
                    OzelKod2Id = model.OzelKod2Id,
                    OzelKod3Id = model.OzelKod3Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Cari cari = _cariService.Get(a => a.Id == id);
            if (cari != null)
            {
                _cariService.RecordHide(id, true);
                _cariService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<CariExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<CariExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}