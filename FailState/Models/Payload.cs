using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FailState.Models
{
    public class Payload
    {
        public bool Success { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public ErrorDetails ErrorDetails { get; set; }
    }
}
