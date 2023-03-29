using Microsoft.AspNetCore.Mvc;
using Katabo.Models;
using NToastNotify;

namespace Katabo.Controllers
{
	public class userRegisterController : Controller
	{
		private readonly KataboContext _db;
		private readonly IToastNotification _toastNotification;

		public userRegisterController(KataboContext db, IToastNotification toastNotification)
		{
			_db = db;
			_toastNotification = toastNotification;
		}

		public IActionResult Index()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			return View();
		}

		[HttpPost]
		public IActionResult Index(User Usr )
		{
			if(Usr.Role == null || Usr.Role.Length == 0)
			{
				Usr.Role = "User";

			}
			Usr.Username = Usr.Email;
			_db.Add(Usr);
			_db.SaveChanges();
			_toastNotification.AddSuccessToastMessage("Registered Successfully!");
			return RedirectToAction("Index", "Home");
		}

	}
}
