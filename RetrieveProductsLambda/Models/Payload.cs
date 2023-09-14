using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrieveProductsLambda.Models
{
    public class Payload
    {
        public IEnumerable<string> ProductIds { get; set; }
    }
}
