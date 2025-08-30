namespace myNotification.Domain.WhatsApp;

public sealed record SendResult(
    bool Success,
    string? ProviderMessageId,
    string? Error
);
