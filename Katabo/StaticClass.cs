using Katabo.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Katabo
{
    public  class StaticClass
    {
        public static List<Cart> myCart { get; set; }
        public static string CurrentUser { get; set; }
        public static int Userid { get; set; }
        public static string Address { get; set; }
        public static double Amount { get; set; }
        public static double Delivery { get; set; }

        public static double NetAmount { get; set; }
        public static double GrossAmount { get; set; }
        public static string Role { get; set; }
        public static int CartCount { get; set; }
        public static string Instructions { get; set; }
        public  StaticClass()
        {
            myCart = new List<Cart>();
            CartCount = 0;
            Userid = -1;
        }
    }

}
