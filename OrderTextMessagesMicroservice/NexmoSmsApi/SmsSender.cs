using Nexmo.Api;
using Nexmo.Api.Messaging;
using Nexmo.Api.Request;
using OrderTextMessagesMicroservice.Core;
using System;
using System.Linq;

namespace OrderTextMessagesMicroservice.NexmoSmsApi
{
    public static class SmsSender
    {
        public static Message Execute(string restaurantName, string deliveryTime, string customerPhoneNumber)
        {
            var TO_NUMBER = customerPhoneNumber;
            var FROM_NAME = "Takeaway.com";
            var TEXT = $"Thank you for ordering from {restaurantName}! You will recieve your order in {deliveryTime}.";
            var NEXMO_API_KEY = Environment.GetEnvironmentVariable("NEXMO_API_KEY");
            var NEXMO_API_SECRET = Environment.GetEnvironmentVariable("NEXMO_API_SECRET");

            var credentials = Credentials.FromApiKeyAndSecret(
                NEXMO_API_KEY,
                NEXMO_API_SECRET
            );

            var vonageClient = new NexmoClient(credentials);


            SendSmsResponse response = vonageClient.SmsClient.SendAnSms(new SendSmsRequest()
            {
                To = TO_NUMBER,
                From = FROM_NAME,
                Text = TEXT
            });

            return new Message(TEXT, response.Messages.FirstOrDefault().Status);
        }
    }
}
