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
    public class StokController : Controller
    {
        private readonly IStokService _stokService;
        private readonly IOzelKodService _ozelKodService1;
        private readonly IOzelKodService _ozelKodService2;
        private readonly IOzelKodService _ozelKodService3;
        private readonly IStokGrubuService _stokGrubuService;
        private readonly IStokAltGrubuService _stokAltGrubuService;
        private readonly IStokTurService _stokTurService;
        private readonly IMarkaService _markaService;
        private readonly IModelService _modelService;
        private readonly IBirimService _birimService;
        private readonly IDosyaService _dosyaService;
        private readonly IMapper _mapper;
        private static bool _durum;

        public StokController(IStokService stokService,
            IOzelKodService ozelKodService1,
            IOzelKodService ozelKodService2,
            IOzelKodService ozelKodService3,
            IStokGrubuService stokGrubuService,
            IStokAltGrubuService stokAltGrubuService,
            IStokTurService stokTurService,
            IMarkaService markaService,
            IModelService modelService,
            IBirimService birimService,
            IDosyaService dosyaService,
            IMapper mapper)
        {
            _stokService = stokService;
            _ozelKodService1 = ozelKodService1;
            _ozelKodService2 = ozelKodService2;
            _ozelKodService3 = ozelKodService3;
            _stokGrubuService = stokGrubuService;
            _stokAltGrubuService = stokAltGrubuService;
            _stokTurService = stokTurService;
            _markaService = markaService;
            _modelService = modelService;
            _birimService = birimService;
            _dosyaService = dosyaService;
            _mapper = mapper;
        }

        List<StokListDto> CallListByCards()
        {
            return _stokService.GetAllDto(a => a.Durum == _durum && a.Silindi == false).ToList();
        }

        void StokFillParameter()
        {
            ViewBag.StokOzelKodlar1 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Stok, OzelKodSira.Sira1).ToList(), "Id", "OzelKodAdi");
            ViewBag.StokOzelKodlar1 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Stok, OzelKodSira.Sira2).ToList(), "Id", "OzelKodAdi");
            ViewBag.StokOzelKodlar1 = new SelectList(_ozelKodService1.GetAllByActiveCars(true, OzelKodKart.Stok, OzelKodSira.Sira3).ToList(), "Id", "OzelKodAdi");
            ViewBag.StokGruplar = new SelectList(_stokGrubuService.GetAllByActiveCars(true).ToList(), "Id", "StokGrubuAdi");
            ViewBag.StokTurler = new SelectList(_stokTurService.GetAllByActiveCars(true).ToList(), "Id", "StokTurAdi");
            ViewBag.StokMarkalar = new SelectList(_markaService.GetAllByActiveCars(true).ToList(), "Id", "MarkaAdi");
            ViewBag.StokBirimler = new SelectList(_birimService.GetAllByActiveCars(true).ToList(), "Id", "BirimAdi");
            //
            ViewBag.StokAltGruplar = new SelectList(_stokAltGrubuService.GetAll(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "StokAltGrubuAdi");
            ViewBag.StokModeller = new SelectList(_modelService.GetAll(a => a.Durum == true && a.Silindi == false).ToList(), "Id", "ModelAdi");
        }

        public IActionResult Index(bool durum = true)
        {
            ViewBag.AktifKartlar = durum;
            _durum = durum;

            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokKart";

            return View(CallListByCards());
        }

        public IActionResult Add()
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokKart";

            StokFillParameter();

            return View(new StokAddDto
            {
                Kod = _stokService.NewCode(KartTuru.Stok, a => a.Kod)
            });
        }

        [HttpPost]
        public IActionResult Add(StokAddDto model)
        {
            if (ModelState.IsValid)
            {
                _stokService.Insert(new Stok
                {
                    Kod = model.Kod,
                    StokAdi = model.StokAdi,
                    Barkod = model.Barkod,
                    AlisKdv = model.AlisKdv,
                    SatisKdv = model.SatisKdv,
                    AlisKdvDurum = model.AlisKdvDurum,
                    SatisKdvDurum = model.SatisKdvDurum,
                    AlisFiyat1 = model.AlisFiyat1,
                    AlisFiyat2 = model.AlisFiyat2,
                    AlisFiyat3 = model.AlisFiyat3,
                    SatisFiyat1 = model.SatisFiyat1,
                    SatisFiyat2 = model.SatisFiyat2,
                    SatisFiyat3 = model.SatisFiyat3,
                    GecerliFiyat = model.GecerliFiyat,
                    StokTurId = model.StokTurId,
                    StokGrubuId = model.StokGrubuId,
                    StokAltGrubuId = model.StokAltGrubuId,
                    MarkaId = model.MarkaId,
                    ModelId = model.ModelId,
                    BirimId = model.BirimId,
                    OzelKod1Id = model.OzelKod1Id,
                    OzelKod2Id = model.OzelKod2Id,
                    OzelKod3Id = model.OzelKod3Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active-In"] = "stokYonetim";
            TempData["Active"] = "stokKart";

            StokFillParameter();

            StokEditDto model = _stokService.GetDto(a => a.Id == id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StokEditDto model)
        {
            if (ModelState.IsValid)
            {
                _stokService.Update(new Stok
                {
                    Id = model.Id,
                    Kod = model.Kod,
                    StokAdi = model.StokAdi,
                    Barkod = model.Barkod,
                    AlisKdv = model.AlisKdv,
                    SatisKdv = model.SatisKdv,
                    AlisKdvDurum = model.AlisKdvDurum,
                    SatisKdvDurum = model.SatisKdvDurum,
                    AlisFiyat1 = model.AlisFiyat1,
                    AlisFiyat2 = model.AlisFiyat2,
                    AlisFiyat3 = model.AlisFiyat3,
                    SatisFiyat1 = model.SatisFiyat1,
                    SatisFiyat2 = model.SatisFiyat2,
                    SatisFiyat3 = model.SatisFiyat3,
                    GecerliFiyat = model.GecerliFiyat,
                    StokTurId = model.StokTurId,
                    StokGrubuId = model.StokGrubuId,
                    StokAltGrubuId = model.StokAltGrubuId,
                    MarkaId = model.MarkaId,
                    ModelId = model.ModelId,
                    BirimId = model.BirimId,
                    OzelKod1Id = model.OzelKod1Id,
                    OzelKod2Id = model.OzelKod2Id,
                    OzelKod3Id = model.OzelKod3Id,
                    Aciklama = model.Aciklama,
                    Durum = model.Durum,
                    Silindi = false
                });

                _stokService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Stok stok = _stokService.Get(a => a.Id == id);
            if (stok != null)
            {
                _stokService.RecordHide(id, true);
                _stokService.SaveChanges();
            }
            return Json(null);
        }

        public IActionResult Excel()
        {
            return File(_dosyaService.AktarExcel(
                _mapper.Map<List<StokExportDto>>(CallListByCards())),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                Guid.NewGuid() + ".xlsx");
        }

        public IActionResult Pdf()
        {
            var path = _dosyaService.AktarPdf(
                _mapper.Map<List<StokExportDto>>(CallListByCards())
                );

            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}