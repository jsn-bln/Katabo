using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katabo.Models
{
	public class Address
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AddressId { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter barangay")]
		public string Barangay { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter landmark")]
		public string Landmark { get; set; }


		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter city")]
		public string City { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter province")]
		public string Province { get; set; }

		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter zipcode")]
		public string Zipcode { get; set; }


		[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter country")]
		public string Country { get; set; }

		public int? UserId { get; set; }
	}
}
