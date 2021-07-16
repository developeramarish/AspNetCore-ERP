using AutoMapper;
using FinalProject.Erp.Model.Dtos.Identity;
using FinalProject.Erp.Model.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            TempData["ProfilAdiSoyadi"] = $"{appUser.Adi} {appUser.Soyadi}";
            TempData["ProfilKullaniciAdi"] = appUser.UserName;

            return View(_mapper.Map<AppUserEditDto>(appUser));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(a => a.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/profile/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    user.Resim = resimAd;
                }

                user.UserName = model.UserName;
                user.Adi = model.Adi;
                user.Soyadi = model.Soyadi;
                user.Gsm = model.Gsm;
                user.Email = model.Email;
                user.Adres = model.Adres;
                user.Sehir = model.Sehir;
                user.Ilce = model.Ilce;
                user.PostaKodu = model.PostaKodu;
                user.Aciklama = model.Aciklama;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = "güncellendi";
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
    }
}