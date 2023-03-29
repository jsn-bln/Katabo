using Microsoft.AspNetCore.Mvc;

namespace Katabo.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			return View();
		}
	}
}
