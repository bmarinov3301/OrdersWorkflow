using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime.CredentialManagement;
using Common.Helpers;
using Common.Models;

namespace Common.Services
{
    public class ProductService
    {
        private readonly IDynamoDBContext _dbContext;

        public ProductService()
        {
            var settings = EnvironmentHelper.GetEnvironmentVariables();

            var chain = new CredentialProfileStoreChain();
            if (settings.IsDevelopment && chain.TryGetAWSCredentials(settings.AwsProfile, out var credentials))
            {
                var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.EUCentral1);
                _dbContext = new DynamoDBContext(client);
            }
            else
            {
                var client = new AmazonDynamoDBClient();
                _dbContext = new DynamoDBContext(client);
            }
        }

        public async Task<T> GetItemFromDynamo<T>(string id, string key)
        {
            var scanConditions = new List<ScanCondition>
            {
                new ScanCondition(key, ScanOperator.Equal, id)
            };

            var results = await _dbContext.ScanAsync<T>(scanConditions).GetRemainingAsync();

            return results.FirstOrDefault();
        }

        public async Task<string> SaveOrderInDynamo(IEnumerable<Product> products)
        {
            var orderId = Guid.NewGuid().ToString();

            var order = new Order
            {
                OrderId = orderId,
                IsComplete = false,
                Products = products.ToList()
            };

            await _dbContext.SaveAsync(order);

            return orderId;
        }

        public async Task CompleteOrder(string orderId)
        {
            var order = await GetItemFromDynamo<Order>(orderId, "OrderId");
            order.IsComplete = true;

            await _dbContext.SaveAsync(order);
        }

        public string OrderProducts(IEnumerable<Product> products)
        {
            // Simulate external API call
            Thread.Sleep(3000);

            var externalOrderId = Guid.NewGuid().ToString();

            return externalOrderId;
        }
    }
}
