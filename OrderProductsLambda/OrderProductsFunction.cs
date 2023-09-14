using Amazon.Lambda.Core;
using Common.Models;
using Common.Services;
using OrderProductsLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace OrderProductsLambda;

public class OrderProductsFunction
{
    public async Task<Response> FunctionHandler(Payload payload, ILambdaContext context)
    {
        var productService = new ProductService();
        var order = await productService.GetItemFromDynamo<Order>(payload.OrderId, "OrderId");

        // Simulate external API call
        Thread.Sleep(3000);

        bool.TryParse(Environment.GetEnvironmentVariable("SHOULD_THROW_TIMEOUT"), out var shouldThrowTimeout);

        if (shouldThrowTimeout)
        {
            throw new TimeoutException("Imitating API timeout");
        }

        var externalId = productService.OrderProducts(order.Products);
        await productService.CompleteOrder(order.OrderId);

        return new Response
        {
            OrderId = order.OrderId,
            ExternalId = externalId,
            IsApproved = true,
            ProductIds = order.Products.Select(p => p.Id)
        };
    }
}
