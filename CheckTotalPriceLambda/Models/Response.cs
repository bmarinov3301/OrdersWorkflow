using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTotalPriceLambda.Models
{
    public class Response
    {
        public string OrderId { get; set; }
        public bool Success { get; set; }
        public int TotalPrice { get; set; }
    }
}
