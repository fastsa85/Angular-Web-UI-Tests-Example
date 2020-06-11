using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Tests.Models
{
    public class PaymentDetail
    {
        public int PaymentId { get; set; }
        
        public string CardOwnerName { get; set; }
        
        public string CardNumber { get; set; }
        
        public string ExpirationDate { get; set; }
        
        public string CVV { get; set; }
    }
}
