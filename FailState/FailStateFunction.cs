using Amazon.Lambda.Core;
using Common;
using Common.Models;
using FailState.Models;
using System.Net.Http.Headers;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace FailState;

public class FailStateFunction
{
    public Payload FunctionHandler(Payload payload, ILambdaContext context)
    {
        context.Logger.Log($"Fail State received input - {JsonSerializer.Serialize(payload)}");

        return payload;
    }
}
