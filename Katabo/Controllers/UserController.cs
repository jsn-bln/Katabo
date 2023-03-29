using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using NToastNotify;
using System.Data;

namespace Katabo.Controllers
{
	public class UserController : Controller
	{

		private KataboContext _db;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IToastNotification _toastNotification;

		public UserController(KataboContext db, IWebHostEnvironment hostEnvironment,
			IToastNotification toastNotification)
		{
			_db = db;
			_hostEnvironment = hostEnvironment;
			_toastNotification = toastNotification;
		}


		// ACCOUNT --------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult Index(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			var user = _db.Users.FirstOrDefault(user => user.UserId == id);

			return View(user);
		}
		[HttpGet]
		public IActionResult EditAccount(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			var user = _db.Users.FirstOrDefault(user => user.UserId == id);

			return View(user);
		}


		// ADDRESS --------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult Address(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			var address = _db.Addresses.Where(a => a.UserId == id);

			return View(address);
		}

		[HttpGet]
		public IActionResult AddAddress() 
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			string contentRootPath = _hostEnvironment.ContentRootPath;
			string[] barangays = System.IO.File.ReadAllLines(Path.Combine(contentRootPath, "wwwroot/Barangays.txt"));
			ViewBag.Barangays = barangays;

			return View(new Address());
		}

		[HttpPost]
		public IActionResult AddAddress(Address add)
		{
			if (ModelState.IsValid)
			{
				if(add.AddressId != 0)
				{
					_db.Addresses.Update(add);
					_toastNotification.AddSuccessToastMessage("Address updated successfully!");

				}
				else
				{
					_db.Addresses.Add(add);
					_toastNotification.AddSuccessToastMessage("Address added successfully!");

				}
				_db.SaveChanges();
			}
			return RedirectToAction("Address", "User", new { id = StaticClass.Userid});
		}


		[HttpGet]
		public IActionResult DeleteAddress(int id)
		{
			var address = _db.Addresses.FirstOrDefault(a => a.AddressId == id);
			_db.Addresses.Remove(address);
			_db.SaveChanges();
			_toastNotification.AddSuccessToastMessage("Address deleted successfully!");

			return RedirectToAction("Address", "User", new { id = StaticClass.Userid });
		}

		[HttpGet]
		public IActionResult EditAddress(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			string contentRootPath = _hostEnvironment.ContentRootPath;
			string[] barangays = System.IO.File.ReadAllLines(Path.Combine(contentRootPath, "wwwroot/Barangays.txt"));
			ViewBag.Barangays = barangays;

			var address = _db.Addresses.FirstOrDefault( a => a.AddressId == id);
			return View(address);
		}

		[HttpPost]
		public IActionResult SetAddressDefault()
		{
			var uid = Request.Form["UserId"];
			var aid = Request.Form["AddressId"];


			var user = _db.Users.FirstOrDefault( a => a.UserId == int.Parse(uid));
			var add = _db.Addresses.FirstOrDefault(a => a.AddressId == int.Parse(aid));

			var temp_user = new User
			{
				UserId = user.UserId,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Birthday = user.Birthday,
				Gender = user.Gender,
				Role = user.Role,
				PhoneNmber = user.PhoneNmber,
				Password = user.Password,
				cPassword = user.cPassword,
				AddressId = int.Parse(aid),
			};

			_db.Users.Update(temp_user);
			_db.SaveChanges();
			_toastNotification.AddSuccessToastMessage("Default address updated!");

			StaticClass.Address = add.Barangay;

			return RedirectToAction("Address", "User", new { id = user.UserId });
		}

		[HttpGet]
		public IActionResult Orders(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			var orders = _db.Orders.Where(o => o.UserId == id).ToList();




			return View(orders);
		}
	}
}
