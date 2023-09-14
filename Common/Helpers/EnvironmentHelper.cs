using Common.Models;

namespace Common.Helpers
{
    public static class EnvironmentHelper
    {
        public static Settings GetEnvironmentVariables()
        {
            return new Settings
            {
                IsDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development",
                AwsProfile = Environment.GetEnvironmentVariable("AWS_PROFILE"),
                EmailRecipient = Environment.GetEnvironmentVariable("EMAIL_RECIPIENT"),
                DecisionEndpoint = Environment.GetEnvironmentVariable("DECISION_ENDPOINT")
            };
        }
    }
}
