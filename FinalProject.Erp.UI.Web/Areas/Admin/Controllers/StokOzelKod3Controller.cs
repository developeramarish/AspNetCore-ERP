using AutoMapper;
using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Dtos.Parametreler;
using FinalProject.Erp.Model.Entities.Parametreler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class StokOzelKod3Controller : Controller
    {
        private readonly IOzelKodService _ozelKodService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public StokOzelKod3Controller(IOzelKodService ozelKodService, IMapper mapper, IDosyaService dosyaService)
        {
            _ozelKodService = ozelKodService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<OzelKod> CallListByCards()
        {
            return _ozelKodService.GetAllByActiveCars(_durum, OzelKodKart.Stok, OzelKodSira.Sira3).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokOzelKod3";

            return View(_mapper.Map<List<OzelKodListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokOzelKod3";

            return View(new OzelKodAddDto
            {
                Kod = _ozelKodService.NewCode(KartTuru.OzelKod, a => a.Kod, a => a.OzelKodTip == (int)OzelKodKart.Stok && a.OzelKodSira == (int)OzelKodSira.Sira3)
            });
        }

        [HttpPost]
        public IActionResult Add(OzelKodAddDto model)
        {
            if (ModelState.IsValid)
            {
                _ozelKodService.Insert(new OzelKod
                {
                    Kod = model.Kod,
                    OzelKodTip = (int)OzelKodKart.Stok,
                    OzelKodSira = (int)OzelKodSira.Sira3,
                    OzelKodAdi = model.OzelKodAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ozelKodService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokOzelKod3";

            OzelKod ozelKod = _ozelKodService.Get(a => a.Id == id);
            OzelKodEditDto model = new OzelKodEditDto
            {
                Id = ozelKod.Id,
                Kod = ozelKod.Kod,
                OzelKodAdi = ozelKod.OzelKodAdi,
                Aciklama = ozelKod.Aciklama,
                Durum = ozelKod.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(OzelKodEditDto model)
        {
            if (ModelState.IsValid)
            {
                _ozelKodService.Update(new OzelKod
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    OzelKodTip = (int)OzelKodKart.Stok,
                    OzelKodSira = (int)OzelKodSira.Sira3,
                    OzelKodAdi = model.OzelKodAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ozelKodService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            OzelKod ozelKod = _ozelKodService.Get(a => a.Id == id);
            if (ozelKod != null)
            {
                _ozelKodService.RecordHide(id, true);
                _ozelKodService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<OzelKodExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<OzelKodExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}