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
    public class StokTurController : Controller
    {
        private readonly IStokTurService _stokTurService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public StokTurController(IStokTurService stokTurService, IMapper mapper, IDosyaService dosyaService)
        {
            _stokTurService = stokTurService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<StokTur> CallListByCards()
        {
            return _stokTurService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokTur";

            return View(_mapper.Map<List<StokTurListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokTur";

            return View(new StokTurAddDto
            {
                Kod = _stokTurService.NewCode(KartTuru.StokTur, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(StokTurAddDto model)
        {
            if (ModelState.IsValid)
            {
                _stokTurService.Insert(new StokTur
                {
                    Kod = model.Kod,
                    StokTurAdi = model.StokTurAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokTurService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokTur";

            StokTur stokTur = _stokTurService.Get(a => a.Id == id);
            StokTurEditDto model = new StokTurEditDto
            {
                Id = stokTur.Id,
                Kod = stokTur.Kod,
                StokTurAdi = stokTur.StokTurAdi,
                Aciklama = stokTur.Aciklama,
                Durum = stokTur.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StokTurEditDto model)
        {
            if (ModelState.IsValid)
            {
                _stokTurService.Update(new StokTur
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    StokTurAdi = model.StokTurAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokTurService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            StokTur stokTur = _stokTurService.Get(a => a.Id == id);
            if (stokTur != null)
            {
                _stokTurService.RecordHide(id, true);
                _stokTurService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<StokTurExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<StokTurExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}