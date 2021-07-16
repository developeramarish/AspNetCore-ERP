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
    public class StokGrubuController : Controller
    {
        private readonly IStokGrubuService _stokGrubuService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public StokGrubuController(IStokGrubuService stokGrubuService, IMapper mapper, IDosyaService dosyaService)
        {
            _stokGrubuService = stokGrubuService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<StokGrubu> CallListByCards()
        {
            return _stokGrubuService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            return View(_mapper.Map<List<StokGrubuListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            return View(new StokGrubuAddDto
            {
                Kod = _stokGrubuService.NewCode(KartTuru.StokGrubu, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(StokGrubuAddDto model)
        {
            if (ModelState.IsValid)
            {
                _stokGrubuService.Insert(new StokGrubu
                {
                    Kod = model.Kod,
                    StokGrubuAdi = model.StokGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokGrubuService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokGrubu";

            StokGrubu stokGrubu = _stokGrubuService.Get(a => a.Id == id);
            StokGrubuEditDto model = new StokGrubuEditDto
            {
                Id = stokGrubu.Id,
                Kod = stokGrubu.Kod,
                StokGrubuAdi = stokGrubu.StokGrubuAdi,
                Aciklama = stokGrubu.Aciklama,
                Durum = stokGrubu.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StokGrubuEditDto model)
        {
            if (ModelState.IsValid)
            {
                _stokGrubuService.Update(new StokGrubu
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    StokGrubuAdi = model.StokGrubuAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokGrubuService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            StokGrubu stokGrubu = _stokGrubuService.Get(a => a.Id == id);
            if (stokGrubu != null)
            {
                _stokGrubuService.RecordHide(id, true);
                _stokGrubuService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<StokGrubuExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<StokGrubuExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}