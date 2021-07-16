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
    public class CariGrubuController : Controller
    {
        private readonly ICariGrubuService _cariGrubuService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public CariGrubuController(ICariGrubuService cariGrubuService, IMapper mapper, IDosyaService dosyaService)
        {
            _cariGrubuService = cariGrubuService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<CariGrubu> CallListByCards()
        {
            return _cariGrubuService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            return View(_mapper.Map<List<CariGrubuListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            return View(new CariGrubuAddDto
            {
                Kod = _cariGrubuService.NewCode(KartTuru.CariGrubu, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(CariGrubuAddDto model)
        {
            if (ModelState.IsValid)
            {
                _cariGrubuService.Insert(new CariGrubu
                {
                    Kod = model.Kod,
                    CariGrubuAdi = model.CariGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariGrubuService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariGrubu";

            CariGrubu cariGrubu = _cariGrubuService.Get(a => a.Id == id);
            CariGrubuEditDto model = new CariGrubuEditDto
            {
                Id = cariGrubu.Id,
                Kod = cariGrubu.Kod,
                CariGrubuAdi = cariGrubu.CariGrubuAdi,
                Aciklama = cariGrubu.Aciklama,
                Durum = cariGrubu.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CariGrubuEditDto model)
        {
            if (ModelState.IsValid)
            {
                _cariGrubuService.Update(new CariGrubu
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    CariGrubuAdi = model.CariGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _cariGrubuService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CariGrubu cariGrubu = _cariGrubuService.Get(a => a.Id == id);
            if (cariGrubu != null)
            {
                _cariGrubuService.RecordHide(id, true);
                _cariGrubuService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<CariGrubuExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<CariGrubuExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}