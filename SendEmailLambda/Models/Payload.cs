﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailLambda.Models
{
    public class Payload
    {
        public string OrderId { get; set; }
        public bool IsApproved { get; set; }
    }
}
