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
    public class StokAltGrubuController : Controller
    {
        private readonly IStokAltGrubuService _stokAltGrubuService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static int _stokGrubuId;
        private static bool _durum;

        public StokAltGrubuController(IStokAltGrubuService stokAltGrubuService, IMapper mapper, IDosyaService dosyaService)
        {
            _stokAltGrubuService = stokAltGrubuService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<StokAltGrubu> CallListByCards()
        {
            return _stokAltGrubuService.GetAllByActiveCars(_stokGrubuId, _durum).ToList();
        }

        public IActionResult Index(int id, bool durum = true)
        {
            _stokGrubuId = id;
            ViewBag.StokGrubuId = id;
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            return View(_mapper.Map<List<StokAltGrubuListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            return View(new StokAltGrubuAddDto
            {
                StokGrubuId = _stokGrubuId,
                Kod = _stokAltGrubuService.NewCode(KartTuru.StokAltGrubu, a => a.Kod, a => a.StokGrubuId == _stokGrubuId)
            });
        }

        [HttpPost]
        public IActionResult Add(StokAltGrubuAddDto model)
        {
            if (ModelState.IsValid)
            {
                _stokAltGrubuService.Insert(new StokAltGrubu
                {
                    StokGrubuId = model.StokGrubuId,
                    Kod = model.Kod,
                    StokAltGrubuAdi = model.StokAltGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokAltGrubuService.SaveChanges();
                return RedirectToAction("Index", new { id = model.StokGrubuId });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            StokAltGrubu stokAltGrubu = _stokAltGrubuService.Get(a => a.Id == id);
            StokAltGrubuEditDto model = new StokAltGrubuEditDto
            {
                Id = stokAltGrubu.Id,
                StokGrubuId = _stokGrubuId,
                Kod = stokAltGrubu.Kod,
                StokAltGrubuAdi = stokAltGrubu.StokAltGrubuAdi,
                Aciklama = stokAltGrubu.Aciklama,
                Durum = stokAltGrubu.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StokAltGrubuEditDto model)
        {
            if (ModelState.IsValid)
            {
                _stokAltGrubuService.Update(new StokAltGrubu
                {
                    Id = model.Id,
                    StokGrubuId = model.StokGrubuId,
                    Kod = model.Kod,
                    StokAltGrubuAdi = model.StokAltGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokAltGrubuService.SaveChanges();
                return RedirectToAction("Index", new { id = model.StokGrubuId });
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            StokAltGrubu stokAltGrubu = _stokAltGrubuService.Get(a => a.Id == id);
            if (stokAltGrubu != null)
            {
                _stokAltGrubuService.RecordHide(id, true);
                _stokAltGrubuService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<StokAltGrubuExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
               _mapper.Map<List<StokAltGrubuExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}