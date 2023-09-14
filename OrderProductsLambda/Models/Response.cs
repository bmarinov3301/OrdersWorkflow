using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProductsLambda.Models
{
    public class Response
    {
        public string OrderId { get; set; }
        public string ExternalId { get; set; }
        public bool IsApproved { get; set; }
        public IEnumerable<string> ProductIds { get; set; }
    }
}
