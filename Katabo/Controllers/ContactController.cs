using Microsoft.AspNetCore.Mvc;

namespace Katabo.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "isactive";
			ViewBag.AdminP = "text-black";
			return View();
		}
	}
}
