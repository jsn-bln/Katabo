
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katabo.Models
{
	public class ShoppingCarts
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ShoppingCartId { get; set; }
		public string? CartJson { get; set; }
		public int UserId { get; set; }

	}
}
