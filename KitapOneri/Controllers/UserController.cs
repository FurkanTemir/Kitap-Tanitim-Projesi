using KitapOneri.Data.Context;
using KitapOneri.Data.Entities;
using KitapOneri.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace KitapOneri.Controllers
{
    public class UserController : Controller
    {
        private readonly RecommendedContext _recommendedContext;
        public UserController(RecommendedContext recommendedContext)
        {
            _recommendedContext = recommendedContext;
        }
        public IActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Kayit(User user)
        {
            var existUser = _recommendedContext.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (existUser != null)
                return BadRequest();

            if (user.Email == null)
                return BadRequest();

            _recommendedContext.Users.Add(user);
            await _recommendedContext.SaveChangesAsync();
            return RedirectToAction("Giris", "User");
        }
        public IActionResult Giris()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(LoginViewModel p)
        {
            var bilgiler = _recommendedContext.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);

            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,p.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "user not found";
            return View();
        }
    }
}
