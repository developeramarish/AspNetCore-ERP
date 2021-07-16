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
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static int _markaId;
        private static bool _durum;

        public ModelController(IModelService modelService, IMapper mapper, IDosyaService dosyaService)
        {
            _modelService = modelService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<ModelKart> CallListByCards()
        {
            return _modelService.GetAllByActiveCars(_markaId, _durum).ToList();
        }

        public IActionResult Index(int id, bool durum = true)
        {
            _markaId = id;
            ViewBag.MarkaId = id;
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            return View(_mapper.Map<List<ModelListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            return View(new ModelAddDto
            {
                MarkaId = _markaId,
                Kod = _modelService.NewCode(KartTuru.Model, a => a.Kod, a => a.MarkaId == _markaId)
            });
        }

        [HttpPost]
        public IActionResult Add(ModelAddDto model)
        {
            if (ModelState.IsValid)
            {
                _modelService.Insert(new ModelKart
                {
                    MarkaId = model.MarkaId,
                    Kod = model.Kod,
                    ModelAdi = model.ModelAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _modelService.SaveChanges();
                return RedirectToAction("Index", new { id = model.MarkaId });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokMarka";

            ModelKart modelKart = _modelService.Get(a => a.Id == id);
            ModelEditDto model = new ModelEditDto
            {
                Id = modelKart.Id,
                MarkaId = _markaId,
                Kod = modelKart.Kod,
                ModelAdi = modelKart.ModelAdi,
                Aciklama = modelKart.Aciklama,
                Durum = modelKart.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ModelEditDto model)
        {
            if (ModelState.IsValid)
            {
                _modelService.Update(new ModelKart
                {
                    Id = model.Id,
                    MarkaId = model.MarkaId,
                    Kod = model.Kod,
                    ModelAdi = model.ModelAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _modelService.SaveChanges();
                return RedirectToAction("Index", new { id = model.MarkaId });
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ModelKart modelKart = _modelService.Get(a => a.Id == id);
            if (modelKart != null)
            {
                _modelService.RecordHide(id, true);
                _modelService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<ModelExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<ModelExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}