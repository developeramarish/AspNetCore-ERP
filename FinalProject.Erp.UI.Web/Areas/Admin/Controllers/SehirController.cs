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
    public class SehirController : Controller
    {
        private readonly ISehirService _sehirService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public SehirController(ISehirService sehirService, IMapper mapper, IDosyaService dosyaService)
        {
            _sehirService = sehirService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<Sehir> CallListByCards()
        {
            return _sehirService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            return View(_mapper.Map<List<SehirListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            return View(new SehirAddDto
            {
                Kod = _sehirService.NewCode(KartTuru.Sehir, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(SehirAddDto model)
        {
            if (ModelState.IsValid)
            {
                _sehirService.Insert(new Sehir
                {
                    Kod = model.Kod,
                    SehirAdi = model.SehirAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _sehirService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            Sehir sehir = _sehirService.Get(a => a.Id == id);
            SehirEditDto model = new SehirEditDto
            {
                Id = sehir.Id,
                Kod = sehir.Kod,
                SehirAdi = sehir.SehirAdi,
                Aciklama = sehir.Aciklama,
                Durum = sehir.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SehirEditDto model)
        {
            if (ModelState.IsValid)
            {
                _sehirService.Update(new Sehir
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    SehirAdi = model.SehirAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _sehirService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Sehir sehir = _sehirService.Get(a => a.Id == id);
            if (sehir != null)
            {
                _sehirService.RecordHide(id, true);
                _sehirService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<SehirExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<SehirExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}