using Microsoft.AspNetCore.Mvc;

namespace Katabo.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "isactive";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";



			return View();
		}
	}
}
