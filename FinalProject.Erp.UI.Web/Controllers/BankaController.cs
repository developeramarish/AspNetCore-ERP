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
    public class BankaController : Controller
    {
        private readonly IBankaService _bankaService;
        private readonly IOzelKodService _ozelKodService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private static bool _durum;

        public BankaController(IBankaService bankaService, IOzelKodService ozelKodService, IDosyaService dosyaService, IMapper mapper)
        {
            _bankaService = bankaService;
            _ozelKodService = ozelKodService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        List<BankaListDto> CallListByCards()
        {
            return _bankaService.GetAllDto(a => a.Durum == _durum && a.Silindi == false).ToList();
        }

        void BankaFillParameter()
        {
            ViewBag.BankaOzelKodlar = new SelectList(_ozelKodService.GetAllByActiveCars(true, OzelKodKart.Banka, OzelKodSira.Sira1).ToList(), "Id", "OzelKodAdi");
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaKart";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaKart";

            BankaFillParameter();

            return View(new BankaAddDto
            {
                Kod = _bankaService.NewCode(KartTuru.Banka, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(BankaAddDto model)
        {
            if (ModelState.IsValid)
            {
                _bankaService.Insert(new Banka
                {
                    Kod = model.Kod,
                    BankaAdi = model.BankaAdi,
                    BankaSube = model.BankaSube,
                    HesapNo = model.HesapNo,
                    IbanNo = model.IbanNo,
                    Yetkili = model.Yetkili,
                    Telefon = model.Telefon,
                    Faks = model.Faks,
                    Gsm = model.Gsm,
                    OzelKod1Id = model.OzelKod1Id,
                    Email = model.Email,
                    Web = model.Web,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _bankaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaKart";

            BankaFillParameter();

            BankaEditDto model = _bankaService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BankaEditDto model)
        {
            if (ModelState.IsValid)
            {
                _bankaService.Update(new Banka
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    BankaAdi = model.BankaAdi,
                    BankaSube = model.BankaSube,
                    HesapNo = model.HesapNo,
                    IbanNo = model.IbanNo,
                    Yetkili = model.Yetkili,
                    Telefon = model.Telefon,
                    Faks = model.Faks,
                    Gsm = model.Gsm,
                    OzelKod1Id = model.OzelKod1Id,
                    Email = model.Email,
                    Web = model.Web,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _bankaService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Banka banka = _bankaService.Get(a => a.Id == id);
            if (banka != null)
            {
                _bankaService.RecordHide(id, true);
                _bankaService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<BankaExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<BankaExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}