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
    public class StokBirimController : Controller
    {
        private readonly IBirimService _birimService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static bool _durum;

        public StokBirimController(IBirimService birimService, IMapper mapper, IDosyaService dosyaService)
        {
            _birimService = birimService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<Birim> CallListByCards()
        {
            return _birimService.GetAllByActiveCars(_durum).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokBirim";

            return View(_mapper.Map<List<BirimListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokBirim";

            return View(new BirimAddDto
            {
                Kod = _birimService.NewCode(KartTuru.Birim, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(BirimAddDto model)
        {
            if (ModelState.IsValid)
            {
                _birimService.Insert(new Birim
                {
                    Kod = model.Kod,
                    BirimAdi = model.BirimAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _birimService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokBirim";

            Birim birim = _birimService.Get(a => a.Id == id);
            BirimEditDto model = new BirimEditDto
            {
                Id = birim.Id,
                Kod = birim.Kod,
                BirimAdi = birim.BirimAdi,
                Aciklama = birim.Aciklama,
                Durum = birim.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BirimEditDto model)
        {
            if (ModelState.IsValid)
            {
                _birimService.Update(new Birim
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    BirimAdi = model.BirimAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _birimService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Birim birim = _birimService.Get(a => a.Id == id);
            if (birim != null)
            {
                _birimService.RecordHide(id, true);
                _birimService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<BirimExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<BirimExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}