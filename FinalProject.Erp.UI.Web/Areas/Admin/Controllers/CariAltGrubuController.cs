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
    public class CariAltGrubuController : Controller
    {
        private readonly ICariAltGrubuService _cariAltGrubuService;
        private readonly IMapper _mapper;
        private static int _cariGrubuId;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;
        public CariAltGrubuController(ICariAltGrubuService cariAltGrubuService, IMapper mapper, IDosyaService dosyaService)
        {
            _cariAltGrubuService = cariAltGrubuService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<CariAltGrubu> CallListByCards()
        {
            return _cariAltGrubuService.GetAllByActiveCars(_cariGrubuId, _durum).ToList();
        }

        public IActionResult Index(int id, bool durum = true)
        {
            ViewBag.CariGrubuId = id;
            ViewBag.AktifKartlar = durum;
            _cariGrubuId = id;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            return View(_mapper.Map<List<CariAltGrubuListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            return View(new CariAltGrubuAddDto
            {
                CariGrubuId = _cariGrubuId,
                Kod = _cariAltGrubuService.NewCode(KartTuru.CariAltGrubu, a => a.Kod, a => a.CariGrubuId == _cariGrubuId)
            });
        }

        [HttpPost]
        public IActionResult Add(CariAltGrubuAddDto model)
        {
            if (ModelState.IsValid)
            {
                _cariAltGrubuService.Insert(new CariAltGrubu
                {
                    CariGrubuId = model.CariGrubuId,
                    Kod = model.Kod,
                    CariAltGrubuAdi = model.CariAltGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariAltGrubuService.SaveChanges();
                return RedirectToAction("Index", new { id = model.CariGrubuId });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            CariAltGrubu cariAltGrubu = _cariAltGrubuService.Get(a => a.Id == id);
            CariAltGrubuEditDto model = new CariAltGrubuEditDto
            {
                Id = cariAltGrubu.Id,
                CariGrubuId = _cariGrubuId,
                Kod = cariAltGrubu.Kod,
                CariAltGrubuAdi = cariAltGrubu.CariAltGrubuAdi,
                Aciklama = cariAltGrubu.Aciklama,
                Durum = cariAltGrubu.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CariAltGrubuEditDto model)
        {
            if (ModelState.IsValid)
            {
                _cariAltGrubuService.Update(new CariAltGrubu
                {
                    Id = model.Id,
                    CariGrubuId = model.CariGrubuId,
                    Kod = model.Kod,
                    CariAltGrubuAdi = model.CariAltGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariAltGrubuService.SaveChanges();
                return RedirectToAction("Index", new { id = model.CariGrubuId });
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CariAltGrubu cariAltGrubu = _cariAltGrubuService.Get(a => a.Id == id);
            if (cariAltGrubu != null)
            {
                _cariAltGrubuService.RecordHide(id, true);
                _cariAltGrubuService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<CariAltGrubuExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<CariAltGrubuExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}