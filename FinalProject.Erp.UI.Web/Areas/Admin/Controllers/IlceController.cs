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
    public class IlceController : Controller
    {
        private readonly IIlceService _ilceService;
        private readonly IMapper _mapper;
        private readonly IDosyaService _dosyaService;
        private static int _sehirId;
        private static bool _durum;

        public IlceController(IIlceService ilceService, IMapper mapper, IDosyaService dosyaService)
        {
            _ilceService = ilceService;
            _mapper = mapper;
            _dosyaService = dosyaService;
        }

        List<Ilce> CallListByCards()
        {
            return _ilceService.GetAllByActiveCars(_sehirId, _durum).ToList();
        }

        public IActionResult Index(int id, bool durum = true)
        {
            _sehirId = id;
            ViewBag.SehirId = id;
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            return View(_mapper.Map<List<IlceListDto>>(CallListByCards()));
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            return View(new IlceAddDto
            {
                SehirId = _sehirId,
                Kod = _ilceService.NewCode(KartTuru.Ilce, a => a.Kod, a => a.SehirId == _sehirId)
            });
        }

        [HttpPost]
        public IActionResult Add(IlceAddDto model)
        {
            if (ModelState.IsValid)
            {
                _ilceService.Insert(new Ilce
                {
                    SehirId = model.SehirId,
                    Kod = model.Kod,
                    IlceAdi = model.IlceAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ilceService.SaveChanges();
                return RedirectToAction("Index", new { id = model.SehirId });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariSehir";

            Ilce ilce = _ilceService.Get(a => a.Id == id);
            IlceEditDto model = new IlceEditDto
            {
                Id = ilce.Id,
                SehirId = _sehirId,
                Kod = ilce.Kod,
                IlceAdi = ilce.IlceAdi,
                Aciklama = ilce.Aciklama,
                Durum = ilce.Durum
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(IlceEditDto model)
        {
            if (ModelState.IsValid)
            {
                _ilceService.Update(new Ilce
                {
                    Id = model.Id,
                    SehirId = model.SehirId,
                    Kod = model.Kod,
                    IlceAdi = model.IlceAdi,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _ilceService.SaveChanges();
                return RedirectToAction("Index", new { id = model.SehirId });
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Ilce ilce = _ilceService.Get(a => a.Id == id);
            if (ilce != null)
            {
                _ilceService.RecordHide(id, true);
                _ilceService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<IlceExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<IlceExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}