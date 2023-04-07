using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using NuGet.Packaging.Signing;

namespace Katabo.Controllers
{
	public class AdminpanelController : Controller
	{
		private KataboContext _db;
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IToastNotification _toastNotification;

		public AdminpanelController(KataboContext db, IWebHostEnvironment hostEnvironment, 
			IToastNotification toastNotification)
		{
			_db = db;
			_hostEnvironment = hostEnvironment;
			_toastNotification = toastNotification;
		}


		//PRODUCTS --------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult Products()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var prod = _db.Products.ToList();
			var categ = _db.Categories.ToList();
			ViewBag.Cate = categ;

			if(StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}


			return View(prod);
		}
		

		[HttpGet]
		public IActionResult EditProduct(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var prod = _db.Products.FirstOrDefault(p => p.ProductId == id);
			var cat = _db.Categories.ToList();

			ViewBag.Cat = cat;

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			return View(prod);
		}

		[HttpPost]
		public IActionResult EditProduct(Product prod)
		{
			string name = Request.Form["Name"];
			string qty = Request.Form["Qty"];
			string price = Request.Form["Price"];
			string desc = Request.Form["desc"];
			string cate = Request.Form["cate"];
			string fil = "";

			Product pd = _db.Products.Where(x => x.ProductId == prod.ProductId).FirstOrDefault();

			if (Request.Form.Files.Count > 0)
			{
				string fileName = Guid.NewGuid().ToString();
				string wwwRootPath = _hostEnvironment.WebRootPath;
				var uploads = Path.Combine(wwwRootPath, @"Images");
				IFormFile file = Request.Form.Files[0];
				var extension = Path.GetExtension(file.FileName);


				fil = "images\\" + fileName + extension;
				using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
				{
					file.CopyTo(fileStreams);
				}
			}
			else
			{
				fil = pd.Image;
			}

			Product prdct = new Product
			{
				Name = name,
				ProductQuantity = int.Parse(qty),
				Price = int.Parse(price),
				Image = fil,
				ProductDescription = desc,
				CategoryId = int.Parse(cate),
				ProductId = prod.ProductId
			};

			_db.Products.Update(prdct);
			_db.SaveChanges();

			_toastNotification.AddSuccessToastMessage("Edit success!");


			return RedirectToAction("Products", "Adminpanel");
		}

		[HttpGet]
		public IActionResult AddProduct(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";
			var cat = _db.Categories.ToList();

			ViewBag.Cat = cat;

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			return View(new Product());
		}


		[HttpPost]
		public IActionResult AddProduct(Product prod)
		{
			string name = Request.Form["Name"];
			string qty = Request.Form["Qty"];
			string price = Request.Form["Price"];
			string desc = Request.Form["desc"];
			string cate = Request.Form["cate"];
			string fil = "";
			if (Request.Form.Files.Count > 0)
			{
				string fileName = Guid.NewGuid().ToString();
				string wwwRootPath = _hostEnvironment.WebRootPath;
				var uploads = Path.Combine(wwwRootPath, @"Images");
				IFormFile file = Request.Form.Files[0];
				var extension = Path.GetExtension(file.FileName);


				fil = "images\\" + fileName + extension;
				using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
				{
					file.CopyTo(fileStreams);
				}
			}

			Product prdct = new Product
			{
				Name = name,
				ProductQuantity = int.Parse(qty),
				Price = int.Parse(price),
				Image = fil,
				ProductDescription = desc,
				CategoryId = int.Parse(cate)
			};

			_db.Add(prdct);
			_db.SaveChanges();

			_toastNotification.AddSuccessToastMessage("Added product successfully!");
			return RedirectToAction("Products", "Adminpanel");
		}

		[HttpGet]
		public IActionResult DeleteProduct(int id)
		{
			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			var pro = _db.Products.Where(x => x.ProductId == id).FirstOrDefault();
			_db.Remove(pro);
			_db.SaveChanges();

			_toastNotification.AddSuccessToastMessage("Product Deleted Successfully");
			return RedirectToAction("Products", "Adminpanel");
		}

		




		//CATEGORY --------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult Categories()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var categories = _db.Categories.ToList();

			return View(categories);
		}

		public IActionResult AddCategory()
		{
			var cate = _db.Categories.ToList();
			return View(cate);
		}

		[HttpPost]
		public IActionResult AddCategoryDB()
		{
			string name = Request.Form["name"];
			string order = Request.Form["order"];
			string fil = "";
			Category ct = new Category
			{
				Name=name,
				DisplayOrder=int.Parse(order),
				CreatedDateTime=DateTime.Now
			};

			if (Request.Form.Files.Count > 0)
			{
				string fileName = Guid.NewGuid().ToString();
				string wwwRootPath = _hostEnvironment.WebRootPath;
				var uploads = Path.Combine(wwwRootPath, @"Images");
				IFormFile file = Request.Form.Files[0];
				var extension = Path.GetExtension(file.FileName);


				fil = "images\\" + fileName + extension;
				using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
				{
					file.CopyTo(fileStreams);
				}
			}
			_db.Add(ct);
			_db.SaveChanges();
			return RedirectToAction("AddCategory");
		}
		public IActionResult DeleteCate(int cateid)
		{
			var cate = _db.Categories.Where(x => x.CategoryId == cateid).FirstOrDefault();
			_db.Remove(cate);
			_db.SaveChanges();
			return RedirectToAction("AddCategory");
		}


		// ACCOUNTS --------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult Accounts()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";


			var accounts = _db.Users.ToList();

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			return View(accounts);
		}

		[HttpGet]
		public IActionResult EditUser(int id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var user = _db.Users
				.Include(a => a.Address)
				.FirstOrDefault(user => user.UserId == id);

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			return View(user);
		}



		[HttpPost]
		public IActionResult updateAccount(User user)
		{
			string firstname = Request.Form["Firstname"];
			string lastname = Request.Form["Lastname"];
			string email = Request.Form["Email"];
			string birthday = Request.Form["Birthday"];
			string gender = Request.Form["Gender"];
			string role = Request.Form["Role"];
			string phonenmumber = Request.Form["Phonenumber"];
			string password = Request.Form["Password"];
			string cpassword = Request.Form["cPassword"];
			string addressid = Request.Form["AddressId"];


			var user_update = _db.Users.FirstOrDefault(u => u.UserId == user.UserId);




			var temp_user = new User
			{
				UserId = user.UserId,
				Username = user_update.Username,
				FirstName = firstname,
				LastName = lastname,
				Email = user_update.Email,
				Birthday = user_update.Birthday,
				Gender = gender,
				Role = role,
				PhoneNmber = user_update.PhoneNmber,
				Password = password,
				cPassword = cpassword,
				AddressId = user_update.AddressId
			};

			_db.Users.Update(temp_user);
			_db.SaveChanges();

			_toastNotification.AddSuccessToastMessage("Update Success");


			if(user.UserId != null || user.UserId >= 0)
			{
				return RedirectToAction("Index","User", new { id = user.UserId });
			}

			return RedirectToAction("Accounts", "Adminpanel");
		}


		[HttpGet]
		public IActionResult AddAccount()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			return View(new User());
		}

		[HttpGet]
		public IActionResult DeleteAccount(int id) 
		{

			if (StaticClass.Userid == -1 || StaticClass.Role == "User")
			{
				return RedirectToAction("Index", "Error");
			}

			var user = _db.Users.Find(id);
			if (user != null)
			{
				if(user.UserId == StaticClass.Userid)
				{
					_toastNotification.AddErrorToastMessage("Cannot remove logged in account");
				}
				else
				{
					_db.Users.Remove(user);
					_db.SaveChanges();
					_toastNotification.AddSuccessToastMessage("Account Removed successfully");

				}

			}

			return RedirectToAction("Accounts", "Adminpanel");
		}


		// ORDER --------------------------------------------------------------------------------------

		[HttpGet]
		public IActionResult Orders()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var orders = _db.Orders.ToList();

			return View(orders);
		}


		[HttpGet]
		public IActionResult EditOrder(string id)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "isactive";

			var order = _db.Orders.FirstOrDefault(o => o.RefId == id);
			var address = _db.Addresses.FirstOrDefault(a => a.AddressId == order.ShippingAddressId);

			var status = new string[] {"Unpaid","Paid","Delivered","Completed"};

			var orderItems = _db.OrderItems.Where(oi => oi.OrderId == order.OrderId).ToList();

			ViewBag.OrderStatus = status;
			ViewBag.ShipmentAdd = address;
			ViewBag.OrderItems = orderItems;
			return View(order);
		}

		[HttpPost]
		public IActionResult EditOrder(Order order)
		{
			var ord = _db.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
			var isshipped = false;
			if(order.Status != "Delivered")
			{
				isshipped = true;
			}
			else
			{
				isshipped= false;
				StaticClass.SendSms("Your Order is being delivered, be sure to be at the delivery address to pickup your order"
					,"+16476875884");
			}

			if(order.Status == "Completed")
			{
				StaticClass.SendSms("Your order is completed, thank you for ordering from KATABO - Borongan. Have a great day!"
					, "+16476875884");
			}

			Order temp = new Order
			{
				OrderId = ord.OrderId,
				AccountId = ord.AccountId,
				AccountType = ord.AccountType,
				Fullname = ord.Fullname,
				OrderDate = ord.OrderDate,
				TotalAmount = ord.TotalAmount,
				ShippingAddressId = ord.ShippingAddressId,
				BillingAddressId = ord.BillingAddressId,
				RefId = ord.RefId,
				PaymentId = ord.PaymentId,
				Status = order.Status,
				OrderType = ord.OrderType,
				OrderInstruction = ord.OrderInstruction,
				IsShipped = isshipped

			};


			_db.Orders.Update(temp);
			_db.SaveChanges();

			return RedirectToAction("Orders", "Adminpanel");
		}
	}
}