using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NToastNotify;

namespace Katabo.Controllers
{
	public class Userlogin : Controller
	{
		private readonly KataboContext _db;
		private readonly IToastNotification _toastNotification;

		public Userlogin(KataboContext db, IToastNotification toastNotification)
		{
			_toastNotification = toastNotification;
			_db = db;
		}
		public IActionResult Index()
		{

			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";

			return View();
		}

		public IActionResult Logout()
		{
			string cartJson = JsonConvert.SerializeObject(StaticClass.myCart);


			var userCart = _db.Carts.FirstOrDefault(c => c.UserId == StaticClass.Userid);

			if(userCart != null)
			{
				_db.Carts.Update(
					new ShoppingCarts
						{
							ShoppingCartId = userCart.ShoppingCartId,
							CartJson = cartJson,
							UserId = userCart.UserId
						}
					);
				_db.SaveChanges();
			}
			else
			{
				_db.Carts.Add(
					new ShoppingCarts 
						{ 
							ShoppingCartId = 0,
							CartJson = cartJson,
							UserId = StaticClass.Userid	
						}

					);
				_db.SaveChanges();

			}

			StaticClass.Userid = -1;
			StaticClass.CurrentUser = "";
			StaticClass.Role = "";
			StaticClass.Amount = 0;
			StaticClass.Delivery = 0;
			StaticClass.NetAmount = 0;
			StaticClass.CartCount = 0;
			StaticClass.Instructions = "";
			StaticClass.myCart.Clear();



			return RedirectToAction("Index", "Home");
		}


		[HttpPost]
		public IActionResult Login(User Usr)
		{
			var data=_db.Users
					.Include(a => a.Address)
					.FirstOrDefault(x => x.Username == Usr.Username && x.Password == Usr.Password);
			
			
			if (data == null)
			{
				ViewBag.error = "Invalid User Name or Password";
				StaticClass.CurrentUser = "";
				return View("Index");
			}
			else
			{
				var add = _db.Addresses.FirstOrDefault(a => a.UserId == data.UserId);
				var cart = _db.Carts.FirstOrDefault(c => c.UserId == data.UserId);




				StaticClass.CurrentUser = data.FirstName;
				StaticClass.Userid = data.UserId;


				if(data.AddressId != null)
				{
					StaticClass.Address = add.Barangay;
				}
				else
				{
					StaticClass.Address = "Set your address";
				}

				if(cart != null)
				{
					StaticClass.myCart = JsonConvert.DeserializeObject<List<Cart>>(cart.CartJson);
					foreach(Cart obj in StaticClass.myCart)
					{
						StaticClass.Amount += (obj.price * obj.qtyFull) + ((obj.price/2) * obj.qtyHalf);
					}
					StaticClass.NetAmount = StaticClass.Amount + 10;
					StaticClass.CartCount = StaticClass.myCart.Count;
				}



				StaticClass.Role = data.Role;
				return RedirectToAction("Index","Home");
			}

		   
		}

	}
}
