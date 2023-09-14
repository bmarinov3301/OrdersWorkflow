using Amazon.Lambda.Core;
using CheckTotalPriceLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CheckTotalPriceLambda;

public class CheckTotalPriceFunction
{
    public Response FunctionHandler(Payload payload)
    {
        var totalPrice = payload.Products.Sum(p => p.Price);

        return new Response
        {
            OrderId = payload.OrderId,
            TotalPrice = totalPrice
        };
    }
}
