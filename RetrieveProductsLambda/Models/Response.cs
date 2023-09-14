using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveProductsLambda.Models
{
    public class Response
    {
        public string OrderId { get; set; }
        public bool Success { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<string> ProductIds { get; set; }
        public int? AvailableAfter { get; set; }
    }
}
