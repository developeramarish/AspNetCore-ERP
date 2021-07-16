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
    public class KasaVirmanController : Controller
    {
        private readonly IKasaHareketService _kasaHareketService;
        private readonly IKasaService _kasaService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;

        public KasaVirmanController(
            IKasaHareketService kasaHareketService,
            IKasaService kasaService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _kasaHareketService = kasaHareketService;
            _kasaService = kasaService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void KasaHareketFillParameter()
        {
            ViewBag.Kasalar = new SelectList(_kasaService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "KasaAdi");
        }

        List<KasaHareketListDto> CallListByCards()
        {
            return _kasaHareketService.GetAllDto(a => a.Silindi == false & a.HareketTip == TumKasaIslemler.KasaTransfer).ToList();
        }

        public IActionResult Index()
        {
            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaVirman";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaVirman";

            KasaHareketFillParameter();

            return View(new KasaHareketAddDto
            {
                Kod = _kasaHareketService.NewCode(KartTuru.KasaHareket, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(KasaHareketAddDto model)
        {
            if (ModelState.IsValid)
            {
                _kasaHareketService.Insert(new KasaHareket
                {
                    Kod = model.Kod,
                    KasaId = model.KasaId,
                    TransferKasaId = model.TransferKasaId,
                    HareketTip = TumKasaIslemler.KasaTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                _kasaHareketService.Insert(new KasaHareket
                {
                    Kod = "T-" + model.Kod,
                    KasaId = (int)model.TransferKasaId,
                    TransferKasaId = model.KasaId,
                    HareketTip = TumKasaIslemler.KasaTransfer,
                    GC = "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "kasaYonetim";
            TempData["Active"] = "kasaVirman";

            KasaHareketFillParameter();

            KasaHareketEditDto model = _kasaHareketService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(KasaHareketEditDto model)
        {
            if (ModelState.IsValid)
            {
                _kasaHareketService.Update(new KasaHareket
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    KasaId = model.KasaId,
                    TransferKasaId = model.TransferKasaId,
                    HareketTip = TumKasaIslemler.KasaTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                KasaHareket kasaHareket = _kasaHareketService.Get(a => a.Kod == "T-" + model.Kod);
                _kasaHareketService.Update(new KasaHareket
                {
                    Id = kasaHareket.Id,
                    Kod = "T-" + model.Kod,
                    KasaId = (int)model.TransferKasaId,
                    TransferKasaId = model.KasaId,
                    HareketTip = TumKasaIslemler.KasaTransfer,
                    GC = "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            KasaHareket hareket = _kasaHareketService.Get(a => a.Id == id);
            if (hareket != null)
            {
                _kasaHareketService.RecordHide(id, true);
                _kasaHareketService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<KasaVirmanExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<KasaVirmanExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}