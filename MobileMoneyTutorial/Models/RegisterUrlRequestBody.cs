﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileMoneyTutorial.Models
{
    public class RegisterUrlRequestBody
    {
        public string ShortCode { get; set; }
        public string ResponseType { get; set; }
        public string ConfirmationURL { get; set; }
        public string ValidationURL { get; set; }
    }
}
