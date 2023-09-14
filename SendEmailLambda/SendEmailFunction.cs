using Amazon.Lambda.Core;
using Common.Helpers;
using Common.Services;
using SendEmailLambda.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SendEmailLambda;

public class SendEmailFunction
{
    public async Task<Response> FunctionHandler(Payload payload)
    {
        var emailService = new EmailService();
        var messageId = string.Empty;

        if (payload.IsApproved)
        {
            var message = EmailHelper.OrderConfirmationTemplate(payload.OrderId);
            messageId = await emailService.SendEmail(message);
        }
        else
        {
            var message = EmailHelper.OrderRejectionTemplate(payload.OrderId);
            messageId = await emailService.SendEmail(message);
        }

        return new Response
        {
            OrderId = payload.OrderId,
            MessageId = messageId,
            EmailSentAt = DateTime.UtcNow
        };
    }
}
