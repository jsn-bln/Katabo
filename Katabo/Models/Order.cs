using System.ComponentModel.DataAnnotations;

namespace Katabo.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string  Fullname { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public bool IsShipped { get; set; }
        public string? RefId { get; set; }
        public string? PaymentId { get; set; }
        public string Status { get; set; }
        public string OrderType { get; set; }
        public string OrderInstruction { get; set; }
    }
}
