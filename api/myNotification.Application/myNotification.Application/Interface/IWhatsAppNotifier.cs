namespace myNotification.Application.Interface
{
    public interface IWhatsAppNotifier
    {
        Task SendMessageAsync(string to, string message);
    }
}
