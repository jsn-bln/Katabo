﻿using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using System;

namespace Katabo.Controllers
{
	public class HomeController : Controller
	{
		private readonly KataboContext _db;
		private readonly IToastNotification _toastNotification;
		private readonly IWebHostEnvironment _hostEnvironment;

		public HomeController(KataboContext db, IToastNotification toastNotification, IWebHostEnvironment hostEnvironment)
		{
			_db = db;
			_toastNotification = toastNotification;
			_hostEnvironment = hostEnvironment;

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
	
			
			string qty = Request.Form["Qty"];
			string portion = Request.Form["options"];
			var prdct = _db.Products.Where(x => x.ProductId == productid).FirstOrDefault();
			StaticClass.CartCount++;


			int half, full;

			if(portion == "1kg")
			{
				half = 0;
				full = int.Parse(qty);
			}
			else
			{
				half = int.Parse(qty);
				full = 0;
			}


			Cart Ord = new Cart
			{
				productid = productid,
				price = prdct.Price,
				qtyFull = full,
				qtyHalf = half,
				Image = prdct.Image,
				Name = prdct.Name,
				ID = StaticClass.CartCount,
				Userid = StaticClass.Userid
			};

			StaticClass.Amount= StaticClass.Amount + ((Ord.price * Ord.qtyFull) + ((Ord.price/2) * Ord.qtyHalf));
			StaticClass.GrossAmount = StaticClass.Amount;
			StaticClass.NetAmount =  StaticClass.Amount + StaticClass.Delivery;

			foreach(Cart o in StaticClass.myCart)
			{
				if(o.productid == Ord.productid)
				{
					o.qtyFull += Ord.qtyFull;
					o.qtyHalf += Ord.qtyHalf;
					StaticClass.CartCount--;
					_toastNotification.AddSuccessToastMessage(prdct.Name + " added to cart!");
					return RedirectToAction("Index");
				}
			}
				
			StaticClass.myCart.Add(Ord);

			_toastNotification.AddSuccessToastMessage(prdct.Name + " added to cart!");
			return RedirectToAction("Index");
		
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

		[HttpGet]
		public IActionResult GuestView()
		{
			string contentRootPath = _hostEnvironment.ContentRootPath;
			string[] barangays = System.IO.File.ReadAllLines(Path.Combine(contentRootPath, "wwwroot/Barangays.txt"));
			ViewBag.Barangays = barangays;


			return View(new GuestData());
		}
		[HttpPost]
		public IActionResult GuestView(GuestData gd)
		{
			Guest guest = gd.guest;
			Address add = gd.address;

			if(StaticClass.Delivery != 0)
			{
				_db.Addresses.Add(add);
				guest.AddressId = add.AddressId;
			}
			
			_db.Guests.Add(guest);

			_db.SaveChanges();

			StaticClass.guest = guest;
			StaticClass.add = add;

			StaticClass.Instructions = Request.Form["instructions"];

			StaticClass.payop = Request.Form["payment"];


			return RedirectToAction("Buy", "Cart", new { id = guest.GuestId}, "POST");

		}
	}

}