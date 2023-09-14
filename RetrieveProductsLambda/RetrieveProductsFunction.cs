using Amazon.Lambda.Core;
using Common.Services;
using Common.Models;
using RetrieveProductsLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace RetrieveProductsLambda;

public class RetrieveProductsFunction
{
    public async Task<Response> FunctionHandler(Payload payload)
    {
        var productService = new ProductService();
        var productList = new List<Product>();

        Thread.Sleep(5000);

        foreach (var id in payload.ProductIds)
        {
            var product = await productService.GetItemFromDynamo<Product>(id, "Id");
            productList.Add(product);
        }

        var preOrder = productList.FirstOrDefault(x => x.Type.ToLower() == "pre-order");
        if (preOrder != null)
        {
            return new Response
            {
                Success = false,
                ProductIds = payload.ProductIds,
                AvailableAfter = preOrder.AvailableAfter
            };
        }

        var orderId = await productService.SaveOrderInDynamo(productList);

        return new Response
        {
            Success = true,
            OrderId = orderId,
            Products = productList
        };
    }
}
