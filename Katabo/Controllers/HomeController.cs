using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;

namespace Katabo.Controllers
{
	public class HomeController : Controller
	{
		private readonly KataboContext _db;
		private readonly IToastNotification _toastNotification;
		public HomeController(KataboContext db, IToastNotification toastNotification)
		{
			_db = db;
			_toastNotification = toastNotification;
			if (StaticClass.myCart == null)
			{
				StaticClass st = new StaticClass();
			}
		}

		public IActionResult Index()
		{
	
			IEnumerable<Product> products = _db.Products.ToList();
			IEnumerable<Category> categories = _db.Categories.ToList();
			ViewBag.Categories = categories;
			ViewBag.Category = "text-black";
			ViewBag.Home = "isactive";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			return View(products);
		}

		public IActionResult Searchme()
		{
			string str = Request.Form["str"];
			var Dataa = from s in _db.Products
						where EF.Functions.Like(s.Name, "%"+str+"%")
						select s;

			List<Product> Data = (List<Product>)Dataa.ToList();
			IEnumerable<Category> categories = _db.Categories.ToList();
			ViewBag.Categories = categories;

			ViewBag.Category = "text-black";
			ViewBag.Home = "isactive";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			return View("Index",Data);
		}
		public IActionResult SelectedItems(int id)
		{

			IEnumerable<Product> products = _db.Products.Where(x=>x.CategoryId== id);
			IEnumerable<Category> categories = _db.Categories.ToList();
			Category selected = _db.Categories.FirstOrDefault(x=>x.CategoryId == id);

			ViewBag.CatName = selected.Name;
			ViewBag.Categories = categories;
			ViewBag.CategorySelected = id;


			ViewBag.Category = "text-black";
			ViewBag.Home = "isactive";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			return View("Index",products);
		}

		[HttpPost]
		public IActionResult buynow(int productid)
		{
			if (StaticClass.Userid > 0)
			{
				string qty = Request.Form["Qty"];
				string portion = Request.Form["options"];
				var prdct = _db.Products.Where(x => x.ProductId == productid).FirstOrDefault();
				StaticClass.CartCount++;

				var price = portion == "1kg" ? prdct.Price : prdct.Price/2;
			
				Cart Ord = new Cart
				{
					productid = productid,
					price = price,
					qty = int.Parse(qty),
					Image = prdct.Image,
					Name = prdct.Name,
					ID = StaticClass.CartCount,
					Userid = StaticClass.Userid
				};

				StaticClass.Amount= StaticClass.Amount + (Ord.price * Ord.qty);
				StaticClass.Delivery = 10;
				StaticClass.GrossAmount = StaticClass.Amount;
				StaticClass.NetAmount =  StaticClass.Amount + StaticClass.Delivery;
				StaticClass.myCart.Add(Ord);

				_toastNotification.AddSuccessToastMessage(prdct.Name + " added to cart!");
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index","Userlogin");
			}
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var prod = _db.Products.FirstOrDefault(p => p.ProductId == id);


			var random = new Random();
			var products = _db.Products
				.Where(p => p.ProductQuantity > 0)
				.ToList();

			var randomProducts = products
				.OrderBy(p => random.Next())
				.Take(6)
				.ToList();

			var availableRandomProducts = randomProducts
				.Where(p => p.ProductQuantity > 0)
				.ToList();

			ViewBag.Category = "isactive";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			ViewBag.ProdsToShow = availableRandomProducts;

			ViewBag.Count = 1;
			

			return View(prod);
		}

	}

}