using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class EmailHelper
    {
        public static Message ManualApprovalTemplate(string decisionBaseUrl, string taskToken, string orderId)
        {
            return new Message
            {
                Subject = new Content("Order decision"),
                Body = new Body
                {
                    Html = new Content
                    {
                        Charset = "UTF-8",
                        Data = $"<html>" +
                            $"<body>" +
                            $"<p>Please confirm or reject order:</p>" +
                            $"<p><a href='{decisionBaseUrl}/orders/approve/{orderId}?taskToken={WebUtility.UrlEncode(taskToken)}'>Confirm order...</a></p>" +
                            $"<p><a href='{decisionBaseUrl}/orders/reject/{orderId}?taskToken={WebUtility.UrlEncode(taskToken)}'>Reject order...</a></p>" +
                            $"</body>" +
                            $"</html>"
                    }
                }
            };
        }

        public static Message OrderConfirmationTemplate(string orderId)
        {
            return new Message
            {
                Subject = new Content("Order confirmed"),
                Body = new Body
                {
                    Text = new Content
                    {
                        Charset = "UTF-8",
                        Data = $"Order {orderId} has been confirmed"
                    }
                }
            };
        }

        public static Message OrderRejectionTemplate(string orderId)
        {
            return new Message
            {
                Subject = new Content("Order rejected"),
                Body = new Body
                {
                    Text = new Content
                    {
                        Charset = "UTF-8",
                        Data = $"Order {orderId} has been rejected"
                    }
                }
            };
        }
    }
}
