using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileMoneyTutorial.Models
{
    public class C2BSimulateRequestBody
    {
        public string ShortCode { get; set; }
        public string CommandID { get; set; }
        public string Amount { get; set; }
        public string Msisdn { get; set; }
        public string BillRefNumber { get; set; }

    }
}
