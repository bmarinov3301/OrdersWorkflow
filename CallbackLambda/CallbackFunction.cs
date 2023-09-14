using Amazon.Lambda.Core;
using CallbackLambda.Models;
using Common.Helpers;
using Common.Services;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CallbackLambda;

public class CallbackFunction
{
    public async Task<Payload> FunctionHandler(Payload payload, ILambdaContext context)
    {
        context.Logger.Log($"Callback payload received - ${JsonSerializer.Serialize(payload)}");

        var emailService = new EmailService();
        var settings = EnvironmentHelper.GetEnvironmentVariables();

        var message = EmailHelper.ManualApprovalTemplate(settings.DecisionEndpoint, payload.TaskToken, payload.OrderId);
        var messageId = await emailService.SendEmail(message);

        context.Logger.Log($"Email sent. Message ID - {messageId}");

        return payload;
    }
}
