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
    public class UlkeController : Controller
    {
        private readonly IUlkeService _ulkeService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public UlkeController(IUlkeService ulkeService, IMapper mapper, IDosyaService dosyaService)
        {
            _ulkeService = ulkeService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<Ulke> CallListByCards()
        {
            return _ulkeService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariUlke";

            return View(_mapper.Map<List<UlkeListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariUlke";

            return View(new UlkeAddDto
            {
                Kod = _ulkeService.NewCode(KartTuru.Ulke, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(UlkeAddDto model)
        {
            if (ModelState.IsValid)
            {
                _ulkeService.Insert(new Ulke
                {
                    Kod = model.Kod,
                    UlkeAdi = model.UlkeAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ulkeService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariUlke";

            Ulke ulke = _ulkeService.Get(a => a.Id == id);
            UlkeEditDto model = new UlkeEditDto
            {
                Id = ulke.Id,
                Kod = ulke.Kod,
                UlkeAdi = ulke.UlkeAdi,
                Aciklama = ulke.Aciklama,
                Durum = ulke.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UlkeEditDto model)
        {
            if (ModelState.IsValid)
            {
                _ulkeService.Update(new Ulke
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    UlkeAdi = model.UlkeAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ulkeService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Ulke ulke = _ulkeService.Get(a => a.Id == id);
            if (ulke != null)
            {
                _ulkeService.RecordHide(id, true);
                _ulkeService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<UlkeExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<UlkeExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}