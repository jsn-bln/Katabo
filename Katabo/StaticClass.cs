using Katabo.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

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
        public static Address add { get; set; }
        public static Guest guest { get; set; }
        public static string payop { get; set; }

        public  StaticClass()
        {
            myCart = new List<Cart>();
            CartCount = 0;
            Userid = -1;
        }

        public static void SendSms(string body, string phonenumber)
        {
            string accountSid = "ACe0d66c5c741de0b81f0e4df3d64ddd0c";
            string authToken = "56d16b0e70bfc1cc82c29aa362797a91";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: body,
                from: new Twilio.Types.PhoneNumber("+15077095981"),
                to: new Twilio.Types.PhoneNumber(phonenumber)

            );
        }
    }

}
