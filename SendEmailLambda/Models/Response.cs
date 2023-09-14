namespace SendEmailLambda.Models
{
    public class Response
    {
        public string OrderId { get; set; }
        public string MessageId { get; set; }
        public DateTime? EmailSentAt { get; set; }
    }
}
