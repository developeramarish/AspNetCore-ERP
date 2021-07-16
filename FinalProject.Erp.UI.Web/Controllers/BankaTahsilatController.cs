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
    public class BankaTahsilatController : Controller
    {
        private readonly IBankaHareketService _bankaHareketService;
        private readonly ICariHareketService _cariHareketService;
        private readonly IBankaService _bankaService;
        private readonly ICariService _cariService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;

        public BankaTahsilatController(
            IBankaHareketService bankaHareketService,
            ICariHareketService cariHareketService,
            IBankaService bankaService, 
            ICariService cariService, 
            IDosyaService dosyaService, 
            IMapper mapper)
        {
            _bankaHareketService = bankaHareketService;
            _cariHareketService = cariHareketService;
            _bankaService = bankaService;
            _cariService = cariService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void BankaHareketFillParameter()
        {
            ViewBag.Bankalar = new SelectList(_bankaService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "BankaAdi");
            ViewBag.Cariler = new SelectList(_cariService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "CariUnvani");
        }

        List<BankaHareketListDto> CallListByCards()
        {
            return _bankaHareketService.GetAllDto(a => a.Silindi == false & (a.HareketTip == TumBankaIslemler.GelenHavale || a.HareketTip == TumBankaIslemler.GidenHavale)).ToList();
        }

        public IActionResult Index()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "bankaTahsilat";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "bankaTahsilat";

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
                    CariId = model.CariId,
                    HareketTip = model.HareketTip,
                    GC = model.HareketTip == TumBankaIslemler.GelenHavale ? "G" : "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                _cariHareketService.Insert(new CariHareket
                {
                    Kod = "T-" + model.Kod,
                    BankaId = model.BankaId,
                    CariId = (int)model.CariId,
                    HareketTip = (TumCariIslemler)model.HareketTip,
                    GC = model.HareketTip == TumBankaIslemler.GelenHavale ? "C" : "G",
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
            TempData["Active"] = "bankaTahsilat";

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
                    CariId = model.CariId,
                    HareketTip = model.HareketTip,
                    GC = model.HareketTip == TumBankaIslemler.GelenHavale ? "G" : "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _bankaHareketService.SaveChanges();

                CariHareket cariHareket = _cariHareketService.Get(a => a.Kod == "T-" + model.Kod);
                _cariHareketService.Update(new CariHareket
                {
                    Id = cariHareket.Id,
                    Kod = "T-" + model.Kod,
                    BankaId = model.BankaId,
                    CariId = (int)model.CariId,
                    HareketTip = (TumCariIslemler)model.HareketTip,
                    GC = model.HareketTip == TumBankaIslemler.GelenHavale ? "C" : "G",
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
                _mapper.Map<List<BankaTahsilatExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<BankaTahsilatExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}