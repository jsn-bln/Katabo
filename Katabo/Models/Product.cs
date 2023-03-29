using System.ComponentModel.DataAnnotations;
namespace Katabo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        [StringLength(100, ErrorMessage = "The product name must be between 1 and 100 characters long.")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a price.")]
        [Range(0, double.MaxValue, ErrorMessage = "The price must be a positive number.")]
        public double Price { get; set; }

        [Required]
        public int ProductQuantity { get; set; }
    }

}
