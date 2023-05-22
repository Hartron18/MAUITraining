using MAUITraining.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MAUITraining.Models
{
    internal class PaymentInfo
    {
        public PaymentInfo()
        {
        }

        public string Name { get; set; } = "Harry";
        public string Email { get; set; } = "analuisa.periera2600@gmail.com";
        public double Amount { get; set; } = 5000;
        public string UserGUID { get; set;} = Guid.NewGuid().ToString();
        public string RedirectUrl { get; set; } = "https://paystack.com/pay/uga0y293ab";
    }
}
