using Common.Models;

namespace CheckTotalPriceLambda.Models
{
    public class Payload
    {
        public string OrderId { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
