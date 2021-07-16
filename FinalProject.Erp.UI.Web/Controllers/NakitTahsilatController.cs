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
using System.Threading.Tasks;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class NakitTahsilatController : Controller
    {
        private readonly IKasaHareketService _kasaHareketService;
        private readonly ICariHareketService _cariHareketService;
        private readonly IKasaService _kasaService;
        private readonly ICariService _cariService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;

        public NakitTahsilatController(
            IKasaHareketService kasaHareketService,
            ICariHareketService cariHareketService,
            IKasaService kasaService,
            ICariService cariService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _kasaHareketService = kasaHareketService;
            _cariHareketService = cariHareketService;
            _kasaService = kasaService;
            _cariService = cariService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void KasaHareketFillParameter()
        {
            ViewBag.Kasalar = new SelectList(_kasaService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "KasaAdi");
            ViewBag.Cariler = new SelectList(_cariService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "CariUnvani");
        }

        List<KasaHareketListDto> CallListByCards()
        {
            return _kasaHareketService.GetAllDto(a => a.Silindi == false & (a.HareketTip == TumKasaIslemler.NakitTahsilat || a.HareketTip == TumKasaIslemler.NakitOdeme)).ToList();
        }

        public IActionResult Index()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "nakitTahsilat";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "nakitTahsilat";

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
                    CariId = model.CariId,
                    HareketTip = model.HareketTip,
                    GC = model.HareketTip == TumKasaIslemler.NakitOdeme ? "G" : "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                _cariHareketService.Insert(new CariHareket
                {
                    Kod = "T-" + model.Kod,
                    KasaId = model.KasaId,
                    CariId = (int)model.CariId,
                    HareketTip = (TumCariIslemler)model.HareketTip,
                    GC = model.HareketTip == TumKasaIslemler.NakitOdeme ? "C" : "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _cariHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "nakitTahsilat";

            KasaHareketFillParameter();

            CariHareketEditDto model = _cariHareketService.GetDto(a => a.Id == id);

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
                    CariId = model.CariId,
                    HareketTip = model.HareketTip,
                    GC = model.HareketTip == TumKasaIslemler.NakitOdeme ? "G" : "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _kasaHareketService.SaveChanges();

                CariHareket cariHareket = _cariHareketService.Get(a => a.Kod == "T-" + model.Kod);
                _cariHareketService.Update(new CariHareket
                {
                    Id = cariHareket.Id,
                    Kod = "T-" + model.Kod,
                    BankaId = model.BankaId,
                    CariId = (int)model.CariId,
                    HareketTip = (TumCariIslemler)model.HareketTip,
                    GC = model.HareketTip == TumKasaIslemler.NakitOdeme ? "C" : "G",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _cariHareketService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            CariHareket hareket = _cariHareketService.Get(a => a.Id == id);
            if (hareket != null)
            {
                _cariHareketService.RecordHide(id, true);
                _cariHareketService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<KasaTahsilatExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<KasaTahsilatExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}