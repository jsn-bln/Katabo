using MessagePack;
using Microsoft.AspNetCore.Razor.Language;

namespace Katabo.Models
{
	public class Cart
	{
   
		public int ID { get; set; }
		public  int productid { get; set; }
		public int Userid { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int qtyFull { get; set; }
		public int qtyHalf { get; set; }

		public double price { get; set; }
	}
}
