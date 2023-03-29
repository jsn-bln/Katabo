using Katabo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Katabo.Controllers
{
	public class CategoryController : Controller
	{
		private readonly KataboContext _db;

		public CategoryController(KataboContext db)
		{
			_db = db;   
		}
		public IActionResult Index()
		{
			var objCategoryList = _db.Categories.ToList();
			ViewBag.Categories = objCategoryList;

			// to change the nav link style when active
			ViewBag.Category = "isactive";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			return View(objCategoryList);
		}

		public IActionResult showProducts(int catid)
		{
			return RedirectToAction("SelectedItems", "Home",new {id= catid });
		}
	}
}
