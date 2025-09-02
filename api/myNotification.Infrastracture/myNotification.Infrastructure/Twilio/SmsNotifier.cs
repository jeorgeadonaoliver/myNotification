using myNotification.Application.Interface;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace myNotification.Infrastructure.Twilio
{
    public class SmsNotifier : ISmsNotifier
    {
        private readonly string _fromNumber;
        public SmsNotifier(string fromNumber)
        {
            _fromNumber = fromNumber;
        }

        public async Task SendMessageAsync(string to, string message)
        {
            var result = await MessageResource.CreateAsync(
                messagingServiceSid: "MGcdc30ab93fed66a91c181e05af7ba7ee",
                to: new PhoneNumber(to),
                body: message
            );
        }
    }
}
