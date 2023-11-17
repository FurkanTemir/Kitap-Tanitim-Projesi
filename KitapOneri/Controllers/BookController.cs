using FalfalaLoginRegister.Data.Context;
using FalfalaLoginRegister.Models;
using KitapOneri.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FalfalaLoginRegister.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly FalfalaContext _context;

        public ProfileController(FalfalaContext context)
        {
            _context = context;
        }

        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var parsedUserId = int.Parse(userId);

            var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == parsedUserId);

            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfileGuncelle(User model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var parsedUserId = int.Parse(userId);

                var userProfile = _context.Profiles.FirstOrDefault(p => p.UserId == parsedUserId);

                if (userProfile == null)
                {
                    return NotFound();
                }

                // Kullanıcının profil bilgilerini güncelle
                userProfile.Name = model.Name;
                userProfile.Email = model.Email;
                userProfile.City = model.City;
                userProfile.PhoneNumber = model.PhoneNumber;
                userProfile.Surname = model.Surname;
                userProfile.BirthDay = model.BirthDay;
                userProfile.Gender = model.Gender;
                userProfile.Job = model.Job;
                userProfile.MaritalStatus = model.MaritalStatus;
                // Diğer profil özelliklerini güncelle

                _context.SaveChanges(); // Veritabanında güncelleme işlemi

                // Profil bilgileri başarıyla güncellendi
                return RedirectToAction("Profile");
            }

            // Geçersiz model durumu veya güncelleme başarısız
            return View("Profile", model);
        }
    }
}
