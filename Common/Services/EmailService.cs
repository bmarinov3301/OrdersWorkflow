using Amazon.Runtime.CredentialManagement;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Common.Helpers;
using Common.Models;
using System.Net;

namespace Common.Services
{
    public class EmailService
    {
        private readonly IAmazonSimpleEmailService _sesClient;
        private readonly Settings _settings;

        public EmailService()
        {
            _settings = EnvironmentHelper.GetEnvironmentVariables();

            var chain = new CredentialProfileStoreChain();
            if (_settings.IsDevelopment && chain.TryGetAWSCredentials(_settings.AwsProfile, out var credentials))
            {
                _sesClient = new AmazonSimpleEmailServiceClient(credentials);
            }
            else
            {
                _sesClient = new AmazonSimpleEmailServiceClient();
            }
        }

        public async Task<string> SendEmail(Message message)
        {
            var request = new SendEmailRequest
            {
                Source = "",
                Destination = new Destination
                {
                    ToAddresses = new List<string>
                    {
                        _settings.EmailRecipient
                    }
                },
                Message = message
            };

            var response = await _sesClient.SendEmailAsync(request);

            return response.MessageId;
        }
    }
}
