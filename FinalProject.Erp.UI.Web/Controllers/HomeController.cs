using FinalProject.Erp.Business.Logger.Base;
using FinalProject.Erp.Common.Tools;
using FinalProject.Erp.Model.Dtos.Identity;
using FinalProject.Erp.Model.Entities.Identity;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FinalProject.Erp.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICustomLogger _logger;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICustomLogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserSignDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result= await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        ErpVariables.AktifPersonelId = user.Id;
                        return RedirectToAction("Index", "General");
                    }
                }

                ModelState.AddModelError("", "Kullanıcı adı/şifre hatalıdır !");
            }

            return View("Index", model);
        }

        public IActionResult Register()
        {
            return View(new AppUserAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Adi = model.Adi,
                    Soyadi = model.Soyadi,
                    Gsm = model.Gsm,
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Exit()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Üzgünüz :) aradığınız sayfa bulunamadı !";
            }

            return View();
        }

        public IActionResult Error()
        {
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"Hatanın oluştuğu yer :{exceptionHandler.Path}\nHatanın mesajı :{exceptionHandler.Error.Message}\nStack Trace :{exceptionHandler.Error.StackTrace}");

            ViewBag.Path = exceptionHandler.Path;
            ViewBag.Message = exceptionHandler.Error.Message;

            return View();
        }

        public void Hata()
        {
            throw new Exception("Bu bir hata");
        }
    }
}