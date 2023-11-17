using KitapOneri.Data.Context;
using KitapOneri.Data.Entities;
using KitapOneri.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KitapOneri.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly RecommendedContext _recommendedContext;
        public HomeController(RecommendedContext recommendedContext)
        {
            _recommendedContext = recommendedContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Giris", "User");
        }
    }
}