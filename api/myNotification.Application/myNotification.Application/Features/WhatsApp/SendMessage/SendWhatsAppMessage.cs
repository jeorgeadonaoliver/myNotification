using myNotification.Application.Interface;

namespace myNotification.Application.Features.WhatsApp.SendMessage
{
    public class SendWhatsAppMessage
    {
        private readonly IWhatsAppNotifier _whatsAppNotifier;

        public SendWhatsAppMessage(IWhatsAppNotifier whatsAppNotifier)
        {
            _whatsAppNotifier = whatsAppNotifier;
        }

        public async Task<bool> SendMessage(SendMessageCommand command) 
        {
            try
            {
                string message = $"Greetings {command.ApproverName}. I wanted to let you know that new trade submissions are ready for your review. Your expertise is key to getting these finalized, and we appreciate you helping us move the process forward.";

                await _whatsAppNotifier.SendMessageAsync(command.Recipient, message);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }
}
