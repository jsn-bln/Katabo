using Katabo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json.Linq;
using NToastNotify;
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Security.Cryptography;
using System.IO;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Katabo.Controllers
{
	public class CartController : Controller
	{
		public List<Cart> Mycart { get; set; }
		private readonly KataboContext _db;
		private readonly IToastNotification _toastNotification;


		public CartController(KataboContext db, IToastNotification toastNotification)
		{
			_db = db;
			_toastNotification = toastNotification;
			Mycart = StaticClass.myCart;
		}

		public IActionResult Deleteme(int id)
		{
			for (int x = 0; x < StaticClass.myCart.Count; x++)
			{
				int myid = StaticClass.myCart[x].ID;
				int myqtyfull = StaticClass.myCart[x].qtyFull;
				int myqtyhalf = StaticClass.myCart[x].qtyHalf;

				if (myid == id)
				{
					StaticClass.CartCount = StaticClass.CartCount - 1;
					StaticClass.Amount = StaticClass.Amount - ((StaticClass.myCart[x].price * myqtyfull) + (StaticClass.myCart[x].price * myqtyhalf));
					if(StaticClass.Amount <= 0)
					{
						StaticClass.Amount = 0;
						StaticClass.NetAmount = 0;
						StaticClass.Delivery = 0;
					}
					else
					{
						StaticClass.NetAmount = StaticClass.NetAmount - ((StaticClass.myCart[x].price * myqtyfull) + (StaticClass.myCart[x].price * myqtyhalf));
					}

					StaticClass.myCart.RemoveAt(x);
					

				}

			}

			Mycart = StaticClass.myCart;

			return RedirectToAction ("Index");
  
		}
		public IActionResult Index()
		{
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


			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			ViewBag.ProdsToShow = availableRandomProducts;


			return View(StaticClass.myCart);
		}

		[HttpGet]
		public IActionResult PlaceOrder(int id)
		{
			if(StaticClass.Userid > 0)
			{
				var account = _db.Users.FirstOrDefault(u => u.UserId == id);
				var deliveryAddress = _db.Addresses.FirstOrDefault(a => a.AddressId == account.AddressId);

				ViewBag.Category = "text-black";
				ViewBag.Home = "text-black";
				ViewBag.AboutUs = "text-black";
				ViewBag.Contact = "text-black";
				ViewBag.AdminP = "text-black";
				ViewBag.ShippingAdd = deliveryAddress;

				if (StaticClass.myCart.Count <= 0)
				{
					_toastNotification.AddErrorToastMessage("Your cart is empty!");
					return RedirectToAction("Index", "Cart");
				}


				return View(account);
			}
			return RedirectToAction("GuestView", "Home");
			
		}

		[HttpPost]
		public IActionResult Payment()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";

			StaticClass.Instructions = Request.Form["instructions"];

			return View();
		}


		public static string GenerateRefId(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var random = new Random();
			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		[HttpPost]
		public async Task<IActionResult> HandleWebhook()
		{
			var signature = Request.Headers["X-Signature"];
			var payload = "";
			using (var reader = new StreamReader(Request.Body))
			{
				payload = await reader.ReadToEndAsync();
			}

			var secretKey = "sk_test_DejxGUmcvp5mANVfzkDETXBW";
			var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
			var expectedSignature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(payload)));
			if (signature != expectedSignature)
			{
				return new StatusCodeResult((int)HttpStatusCode.BadRequest);
			}


			var eventPayload = JObject.Parse(payload);
			var eventType = (string)eventPayload["data"]["attributes"]["event"];
			var paymentId = (string)eventPayload["data"]["relationships"]["payment"]["data"]["id"];

			if (eventType == "payment.success")
			{



				return RedirectToAction("Success");
			}
			else if (eventType == "payment.failed")
			{

				return RedirectToAction("Failure");
			}


			return new StatusCodeResult((int)HttpStatusCode.OK);

		}

		

		[AcceptVerbs("GET", "POST")]
		public IActionResult Buy(int id)
		{
			string paymentOption = "";
			dynamic account;

			try
			{
				paymentOption = Request.Form["instructions"];
			}catch(InvalidOperationException e)
			{
				paymentOption = StaticClass.payop;
			}
			string payOp = StaticClass.Delivery == 10 ? paymentOption : "PICKUP";

			if(StaticClass.guest != null)
			{
				account = _db.Guests.FirstOrDefault(g => g.GuestId == id);
			}
			else
			{
				account = _db.Users.FirstOrDefault(u => u.UserId == id);
			}

			var accountType = "";
			if (account is User)
			{
				accountType = "User";
			}
			else if (account is Guest)
			{
				accountType = "Guest";
			}

			var toPay = StaticClass.NetAmount;
			try
			{
				StaticClass.Instructions = Request.Form["instructions"];
			}catch(InvalidOperationException e)
			{

			}


			if (paymentOption == "gcash")
			{
				var client = new RestClient("https://api.paymongo.com/v1/links");
				var request = new RestRequest(Method.POST);
				request.AddHeader("accept", "application/json");
				request.AddHeader("content-type", "application/json");
				request.AddHeader("authorization", "Basic c2tfdGVzdF9iMzdyemM2UUwzbnVDeTJabmRudGdqZEU6");

				var amount = StaticClass.NetAmount * 100;
				var description = account.FirstName + " " + account.LastName + " order";
				var remarks = StaticClass.Instructions;

				if(StaticClass.NetAmount < 100)
				{
					_toastNotification.AddErrorToastMessage("Total amount must be greater than 100 to use Gcash");
					return RedirectToAction("Payment", "Cart");
				}


				string payload = $"{{\"data\":{{\"attributes\":{{\"amount\":{amount},\"description\":\"{description}\",\"remarks\":\"{remarks}\"}}}}}}";
				request.AddParameter("application/json", payload, ParameterType.RequestBody);
				IRestResponse response = client.Execute(request);

				if (response.IsSuccessful)
				{
					dynamic paymentLink = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
					string checkoutUrl = paymentLink["data"]["attributes"]["checkout_url"];
					string refid = GenerateRefId(10);
					string paymentid = paymentLink["data"]["id"];
					string status = paymentLink["data"]["attributes"]["status"];

					Order order = new Order
					{
						OrderId = 0,
						AccountId = id,
						AccountType = accountType,
						Fullname = account.FirstName + " " + account.LastName,
						OrderDate = DateTime.Now,
						TotalAmount = (decimal)StaticClass.NetAmount,
						ShippingAddressId = account.AddressId ?? 0,
						BillingAddressId = account.AddressId ?? 0,
						IsShipped = false,
						RefId = refid,
						PaymentId = paymentid,
						Status = status,
						OrderType = payOp.ToUpper(),
						OrderInstruction = StaticClass.Instructions

					};

					_db.Orders.Add(order);
					_db.SaveChanges();

					Order ord = _db.Orders.FirstOrDefault(o => o.RefId == refid);

					foreach (Cart prod in StaticClass.myCart)
					{
						OrderItem temp = new OrderItem
						{
							OrderItemId = 0,
							OrderId = ord.OrderId,
							ProductId = prod.ID,
							ProductName = prod.Name,
							Quantity = prod.qtyFull + (prod.qtyHalf),
							Total = (prod.price * prod.qtyFull) + ((prod.price/2) * prod.qtyHalf)

						};
						_db.OrderItems.Add(temp);
						
					}

					_db.SaveChanges();


				
					
					StaticClass.myCart.Clear();
					StaticClass.GrossAmount = 0;
					StaticClass.NetAmount = 0;
					StaticClass.Amount = 0;
					StaticClass.Delivery = 0;
					StaticClass.CartCount = 0;
					StaticClass.guest = null;
					StaticClass.Address = null;
					StaticClass.payop = "";

					Task.Run(() => StaticClass.SendSms("Your order is being prepared, you will be notified when its being delivered ", "+16476875884"));
					return Redirect(checkoutUrl);

				}
				else
				{
					return RedirectToAction("Failure", "Cart");
				}

			}
			else
			{
				String refid = GenerateRefId(10);
				String paymentid = GenerateRefId(10);
				Order order = new Order
				{
					OrderId = 0,
					AccountId = id,
					AccountType = accountType,
					Fullname = account.FirstName + " " + account.LastName,
					OrderDate = DateTime.Now,
					TotalAmount = (decimal)StaticClass.NetAmount,
					ShippingAddressId = account.AddressId ?? 0,
					BillingAddressId = account.AddressId ?? 0,
					IsShipped = false,
					RefId = refid,
					PaymentId = paymentid,
					Status = "unpaid",
					OrderType = payOp.ToUpper(),
					OrderInstruction = StaticClass.Instructions

				};

				_db.Orders.Add(order);
				_db.SaveChanges();

				Order ord = _db.Orders.FirstOrDefault(o => o.RefId == refid);

				foreach (Cart prod in StaticClass.myCart)
				{
					OrderItem temp = new OrderItem
					{
						OrderItemId = 0,
						OrderId = ord.OrderId,
						ProductId = prod.ID,
						ProductName = prod.Name,
						Quantity = prod.qtyFull + (prod.qtyHalf),
						Total = (prod.price * prod.qtyFull) + ((prod.price / 2) * prod.qtyHalf)

					};
					_db.OrderItems.Add(temp);

				}

				_db.SaveChanges();

				if(StaticClass.Delivery > 0)
				{
					StaticClass.SendSms("Your order is being prepared, you will be notified when its being delivered ", "+16476875884");
				}
				else
				{
					StaticClass.SendSms("Your order is being prepared, you will be notified when its ready for pickup ", "+16476875884");

				}


				StaticClass.myCart.Clear();
				StaticClass.GrossAmount = 0;
				StaticClass.NetAmount = 0;
				StaticClass.Amount = 0;
				StaticClass.Delivery = 0;
				StaticClass.CartCount = 0;
				StaticClass.Instructions = "";
				StaticClass.guest = null;
				StaticClass.Address = null;
				StaticClass.payop = "";






				_toastNotification.AddSuccessToastMessage("Order placed successfuly");
				return RedirectToAction("Index","Home");


			}

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Success()
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			return View();
		}

		[HttpGet]
		public IActionResult Failure(string errorMessage)
		{
			ViewBag.Category = "text-black";
			ViewBag.Home = "text-black";
			ViewBag.AboutUs = "text-black";
			ViewBag.Contact = "text-black";
			ViewBag.AdminP = "text-black";
			ViewBag.ErrorMessage = errorMessage;
			return View();
		}

		[HttpPost]
		public JsonResult UpdateDelivery(int delivery)
		{
			StaticClass.Delivery = delivery;
			StaticClass.NetAmount = StaticClass.Amount + StaticClass.Delivery;
			return Json(new { success = true });
		}




	}
}
