using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katabo.Models
{
	public class Guest
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GuestId { get; set; }

		[Required]
		public String FirstName { get; set; }

		[Required]
		public String LastName { get;set; }

		[Required]
		public String PhoneNumber { get; set; }

		public int? AddressId { get; set; }
	}
}
