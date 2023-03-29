using System.ComponentModel.DataAnnotations;

namespace Katabo.Models
{
	public class OrderItem
	{
		[Key]
		public int OrderItemId { get; set; }

		public int OrderId { get; set; }

		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double Total { get; set; }
		
	}
}
