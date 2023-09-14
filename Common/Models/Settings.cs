namespace Common.Models
{
    public class Settings
    {
        public bool IsDevelopment { get; set; }
        public string? AwsProfile { get; set; }
        public string? EmailRecipient { get; set; }
        public string? DecisionEndpoint { get; set; }
    }
}
