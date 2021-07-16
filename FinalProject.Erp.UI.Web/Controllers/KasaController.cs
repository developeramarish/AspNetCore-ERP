using AutoMapper;
using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Business.Abstract.Parametreler;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class KasaController : Controller
    {
        private readonly IKasaService _kasaService;
        private readonly IOzelKodService _ozelKodService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private static bool _durum;
        public KasaController(IKasaService kasaService, IOzelKodService ozelKodService, IDosyaService dosyaService, IMapper mapper)
        {
            _kasaService = kasaService;
            _ozelKodService = ozelKodService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        List<KasaListDto> CallListByCards()
        {
            return _kasaService.GetAllDto(a => a.Durum == _durum && a.Silindi == false).ToList();
        }

        void KasaFillParameter()
        {
            ViewBag.KasaOzelKodlar = new SelectList(_ozelKodService.GetAllByActiveCars(true, OzelKodKart.Kasa, OzelKodSira.Sira1).ToList(), "Id", "OzelKodAdi");
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaKart";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaKart";

            KasaFillParameter();

            return View(new KasaAddDto
            {
                Kod = _kasaService.NewCode(KartTuru.Banka, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(KasaAddDto model)
        {
            if (ModelState.IsValid)
            {
                _kasaService.Insert(new Kasa
                {
                    Kod = model.Kod,
                    KasaAdi = model.KasaAdi,
                    Yetkili = model.Yetkili,
                    OzelKod1Id = model.OzelKod1Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _kasaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaKart";

            KasaFillParameter();

            KasaEditDto model = _kasaService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(KasaEditDto model)
        {
            if (ModelState.IsValid)
            {
                _kasaService.Update(new Kasa
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    KasaAdi = model.KasaAdi,
                    Yetkili = model.Yetkili,
                    OzelKod1Id = model.OzelKod1Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _kasaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Kasa kasa = _kasaService.Get(a => a.Id == id);
            if (kasa != null)
            {
                _kasaService.RecordHide(id, true);
                _kasaService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<KasaEditDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<KasaExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}