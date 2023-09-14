using Amazon.DynamoDBv2.DataModel;

namespace Common.Models
{
    [DynamoDBTable("dev-bg-orders-table")]
    public class Order
    {
        [DynamoDBHashKey]
        public string OrderId { get; set; }
        public bool IsComplete { get; set; }
        public List<Product> Products { get; set; }
    }
}
