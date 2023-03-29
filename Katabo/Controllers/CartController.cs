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
				int myqty = StaticClass.myCart[x].qty;
				if (myid == id)
				{
					StaticClass.CartCount = StaticClass.CartCount - 1;
					StaticClass.Amount = StaticClass.Amount - (StaticClass.myCart[x].price * myqty);
					if(StaticClass.Amount <= 0)
					{
						StaticClass.Amount = 0;
						StaticClass.NetAmount = 0;
						StaticClass.Delivery = 0;
					}
					else
					{
						StaticClass.NetAmount = StaticClass.NetAmount - (StaticClass.myCart[x].price * myqty);
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


		[HttpPost]
		public IActionResult Buy(int id)
		{
			string paymentOption = Request.Form["payment"];
			var account = _db.Users.FirstOrDefault(u => u.UserId == id);
			var toPay = StaticClass.NetAmount;

			if (paymentOption == "gcash")
			{
				var client = new RestClient("https://api.paymongo.com/v1/links");
				var request = new RestRequest(Method.POST);
				request.AddHeader("accept", "application/json");
				request.AddHeader("content-type", "application/json");
				request.AddHeader("authorization", "Basic c2tfdGVzdF9EZWp4R1VtY3ZwNW1BTlZmemtERVRYQlc6");

				var amount = StaticClass.NetAmount * 100;
				var description = account.FirstName + " " + account.LastName + " order";
				var remarks = account.FirstName + " " + account.LastName + " order";

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
						UserId = account.UserId,
						Fullname = account.FirstName + " " + account.LastName,
						OrderDate = DateTime.Now,
						TotalAmount = (decimal)StaticClass.NetAmount,
						ShippingAddressId = (int)account.AddressId,
						BillingAddressId = (int)account.AddressId,
						IsShipped = false,
						RefId = refid,
						PaymentId = paymentid,
						Status = status,
						OrderType = paymentOption.ToUpper(),
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
							Quantity = prod.qty,
							Total = prod.price * prod.qty

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

					return Redirect(checkoutUrl);
					
				}
				else
				{
					return RedirectToAction("Failure", "Cart");
				}

			}
			else if(paymentOption == "cod" || paymentOption == "pickup")
			{
				String refid = GenerateRefId(10);
				String paymentid = GenerateRefId(10);
				Order order = new Order
				{
					OrderId = 0,
					UserId = account.UserId,
					Fullname = account.FirstName + " " + account.LastName,
					OrderDate = DateTime.Now,
					TotalAmount = (decimal)StaticClass.NetAmount,
					ShippingAddressId = (int)account.AddressId,
					BillingAddressId = (int)account.AddressId,
					IsShipped = false,
					RefId = refid,
					PaymentId = paymentid,
					Status = "unpaid",
					OrderType = paymentOption.ToUpper(),
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
						Quantity = prod.qty,
						Total = prod.price * prod.qty

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
				StaticClass.Instructions = "";

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



	}
}
