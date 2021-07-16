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
    public class MarkaController : Controller
    {
        private readonly IMarkaService _markaService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public MarkaController(IMarkaService markaService, IMapper mapper, IDosyaService dosyaService)
        {
            _markaService = markaService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<Marka> CallListByCards()
        {
            return _markaService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            return View(_mapper.Map<List<MarkaListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            return View(new MarkaAddDto
            {
                Kod = _markaService.NewCode(KartTuru.Marka, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(MarkaAddDto model)
        {
            if (ModelState.IsValid)
            {
                _markaService.Insert(new Marka
                {
                    Kod = model.Kod,
                    MarkaAdi = model.MarkaAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _markaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            Marka marka = _markaService.Get(a => a.Id == id);
            MarkaEditDto model = new MarkaEditDto
            {
                Id = marka.Id,
                Kod = marka.Kod,
                MarkaAdi = marka.MarkaAdi,
                Aciklama = marka.Aciklama,
                Durum = marka.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MarkaEditDto model)
        {
            if (ModelState.IsValid)
            {
                _markaService.Update(new Marka
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    MarkaAdi = model.MarkaAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _markaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Marka marka = _markaService.Get(a => a.Id == id);
            if (marka != null)
            {
                _markaService.RecordHide(id, true);
                _markaService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<MarkaExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<MarkaExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}