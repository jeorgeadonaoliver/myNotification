using myNotification.Application.Interface;

namespace myNotification.Application.Features.Sms.SendMessage
{
    public class SendSmsMessage
    {
        private readonly ISmsNotifier _smsNotifier;

        public SendSmsMessage(ISmsNotifier smsNotifier)
        {
            _smsNotifier = smsNotifier;
        }

        public async Task<bool> SendMessage(SendSmsMessageCommand command)
        {
            try
            {
                string message = $"Greetings {command.ApproverName}. I wanted to let you know that new trade submissions are ready for your review. Your expertise is key to getting these finalized, and we appreciate you helping us move the process forward.";

                await _smsNotifier.SendMessageAsync(command.Recipient, message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }
    }
}
