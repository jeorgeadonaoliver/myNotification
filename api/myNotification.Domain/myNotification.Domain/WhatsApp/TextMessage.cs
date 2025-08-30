namespace myNotification.Domain.WhatsApp;

public class TextMessage(
    string To, // E.164 MSISDN (e.g., "+639171234567")
    string Message, // message body
    string? CorrelationId // optional id for tracing
);
