namespace myNotification.Domain.Twilio
{
    public class TwilioSettings
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string FromNumber { get; set; }

        public string FromSmsNumber { get; set; }
    }

}
