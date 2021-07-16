using AutoMapper;
using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Dtos.Kartlar;
using FinalProject.Erp.Model.Entities.Kartlar;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class DepoController : Controller
    {
        private readonly IDepoService _depoService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private static bool _durum;
        public DepoController(IDepoService depoService, IDosyaService dosyaService, IMapper mapper)
        {
            _depoService = depoService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        List<DepoListDto> CallListByCards()
        {
            return _depoService.GetAllDto(a => a.Durum == _durum && a.Silindi == false).ToList();
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "depoKart";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "depoKart";

            return View(new DepoAddDto
            {
                Kod = _depoService.NewCode(KartTuru.Depo, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(DepoAddDto model)
        {
            if (ModelState.IsValid)
            {
                _depoService.Insert(new Depo
                {
                    Kod = model.Kod,
                    DepoAdi = model.DepoAdi,
                    Yetkili = model.Yetkili,
                    Telefon = model.Telefon,
                    Adres = model.Adres,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _depoService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "depoKart";

            DepoEditDto model = _depoService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DepoEditDto model)
        {
            if (ModelState.IsValid)
            {
                _depoService.Update(new Depo
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    DepoAdi = model.DepoAdi,
                    Yetkili = model.Yetkili,
                    Telefon = model.Telefon,
                    Adres = model.Adres,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _depoService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Depo depo = _depoService.Get(a => a.Id == id);
            if (depo != null)
            {
                _depoService.RecordHide(id, true);
                _depoService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<DepoEditDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<DepoEditDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}