using AutoMapper;
using FinalProject.Erp.Business.Abstract.Dosyalar;
using FinalProject.Erp.Business.Abstract.Hareketler;
using FinalProject.Erp.Business.Abstract.Kartlar;
using FinalProject.Erp.Common.Enums;
using FinalProject.Erp.Model.Dtos.Hareketler;
using FinalProject.Erp.Model.Entities.Hareketler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class BankaVirmanController : Controller
    {
        private readonly IBankaHareketService _bankaHareketService;
        private readonly IBankaService _bankaService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;

        public BankaVirmanController(
            IBankaHareketService bankaHareketService,
            IBankaService bankaService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _bankaHareketService = bankaHareketService;
            _bankaService = bankaService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void BankaHareketFillParameter()
        {
            ViewBag.Bankalar = new SelectList(_bankaService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "BankaAdi");
        }

        List<BankaHareketListDto> CallListByCards()
        {
            return _bankaHareketService.GetAllDto(a => a.Silindi == false & a.HareketTip == TumBankaIslemler.BankaTransfer).ToList();
        }

        public IActionResult Index()
        {
            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaVirman";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaVirman";

            BankaHareketFillParameter();

            return View(new BankaHareketAddDto
            {
                Kod = _bankaHareketService.NewCode(KartTuru.BankaHareket, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(BankaHareketAddDto model)
        {
            if (ModelState.IsValid)
            {
                _bankaHareketService.Insert(new BankaHareket
                {
                    Kod = model.Kod,
                    BankaId = model.BankaId,
                    TransferBankaId = model.TransferBankaId,
                    HareketTip = TumBankaIslemler.BankaTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                _bankaHareketService.Insert(new BankaHareket
                {
                    Kod = "T-" + model.Kod,
                    BankaId = (int)model.TransferBankaId,
                    TransferBankaId = model.BankaId,
                    HareketTip = TumBankaIslemler.BankaTransfer,
                    GC = "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "bankaYonetim";
            TempData["Active"] = "bankaVirman";

            BankaHareketFillParameter();

            BankaHareketEditDto model = _bankaHareketService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BankaHareketEditDto model)
        {
            if (ModelState.IsValid)
            {
                _bankaHareketService.Update(new BankaHareket
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    BankaId = model.BankaId,
                    TransferBankaId = model.TransferBankaId,
                    HareketTip = TumBankaIslemler.BankaTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                BankaHareket bankaHareket = _bankaHareketService.Get(a => a.Kod == "T-" + model.Kod);
                _bankaHareketService.Update(new BankaHareket
                {
                    Id = bankaHareket.Id,
                    Kod = "T-" + model.Kod,
                    BankaId = (int)model.TransferBankaId,
                    TransferBankaId = model.BankaId,
                    HareketTip = TumBankaIslemler.BankaTransfer,
                    GC = "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            BankaHareket hareket = _bankaHareketService.Get(a => a.Id == id);
            if (hareket != null)
            {
                _bankaHareketService.RecordHide(id, true);
                _bankaHareketService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<BankaVirmanExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<BankaVirmanExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}