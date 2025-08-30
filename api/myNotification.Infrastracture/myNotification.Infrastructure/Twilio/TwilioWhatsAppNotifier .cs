using myNotification.Application.Interface;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace myNotification.Infrastructure.Twilio
{
    public class TwilioWhatsAppNotifier : IWhatsAppNotifier
    {
        private readonly string _fromNumber;

        public TwilioWhatsAppNotifier(string fromNumber)
        {
            _fromNumber = fromNumber;
        }

        public async Task SendMessageAsync(string to, string message)
        {
            var result = await MessageResource.CreateAsync(
                from: new PhoneNumber(_fromNumber),
                to: new PhoneNumber($"whatsapp:{to}"),
                body: message
            );
        }
    }
}
