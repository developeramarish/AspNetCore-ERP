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
    public class CariVirmanController : Controller
    {
        private readonly ICariHareketService _cariHareketService;
        private readonly ICariService _cariService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;

        public CariVirmanController(
            ICariHareketService cariHareketService,
            ICariService cariService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _cariHareketService = cariHareketService;
            _cariService = cariService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        void CariHareketFillParameter()
        {
            ViewBag.Cariler = new SelectList(_cariService.GetAllDto(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "CariUnvani");
        }

        List<CariHareketListDto> CallListByCards()
        {
            return _cariHareketService.GetAllDto(a => a.Silindi == false & a.HareketTip == TumCariIslemler.CariTransfer).ToList();
        }

        public IActionResult Index()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariVirman";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "cariYonetim";
            TempData["Active"] = "cariVirman";

            CariHareketFillParameter();

            return View(new CariHareketAddDto
            {
                Kod = _cariHareketService.NewCode(KartTuru.CariHareket, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(CariHareketAddDto model)
        {
            if (ModelState.IsValid)
            {
                _cariHareketService.Insert(new CariHareket
                {
                    Kod = model.Kod,
                    CariId = model.CariId,
                    TransferCariId = model.TransferCariId,
                    HareketTip = TumCariIslemler.CariTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _cariHareketService.SaveChanges();

                _cariHareketService.Insert(new CariHareket
                {
                    Kod = "T-" + model.Kod,
                    CariId = (int)model.TransferCariId,
                    TransferCariId = model.CariId,
                    HareketTip = TumCariIslemler.CariTransfer,
                    GC = "G",
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
            TempData["Active"] = "cariVirman";

            CariHareketFillParameter();

            CariHareketEditDto model = _cariHareketService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CariHareketEditDto model)
        {
            if (ModelState.IsValid)
            {
                _cariHareketService.Update(new CariHareket
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    CariId = model.CariId,
                    TransferCariId = model.TransferCariId,
                    HareketTip = TumCariIslemler.CariTransfer,
                    GC = "C",
                    Tarih = model.Tarih,
                    MakbuzNo = model.MakbuzNo,
                    Tutar = model.Tutar,
                    Aciklama = model.Aciklama,
                    Silindi = false
                });
                _cariHareketService.SaveChanges();

                CariHareket cariHareket = _cariHareketService.Get(a => a.Kod == "T-" + model.Kod);
                _cariHareketService.Update(new CariHareket
                {
                    Id = cariHareket.Id,
                    Kod = "T-" + model.Kod,
                    CariId = (int)model.TransferCariId,
                    TransferCariId = model.CariId,
                    HareketTip = TumCariIslemler.CariTransfer,
                    GC = "G",
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
                _mapper.Map<List<CariVirmanExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<CariVirmanExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}