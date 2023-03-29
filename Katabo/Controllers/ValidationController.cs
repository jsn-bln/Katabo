using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Katabo.Controllers
{
    public class ValidationController : Controller
    {
        private readonly KataboContext _db;
        public ValidationController(KataboContext db)
        {
            _db = db;
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult IsEmailUnique(string email)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return Json($"The email address '{email}' is already registered.");
            }
            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult IsPhoneUnique(string phoneNumber)
        {
            var user = _db.Users.FirstOrDefault(u => u.PhoneNmber == phoneNumber);
            if (user != null)
            {
                return Json($"The phone number '{phoneNumber}' is already registered.");
            }
            return Json(true);
        }
    }
}
