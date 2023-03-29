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
        public int qty { get; set; }
        public double price { get; set; }
    }
}
