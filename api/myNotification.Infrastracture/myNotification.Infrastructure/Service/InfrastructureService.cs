using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myNotification.Application.Interface;
using myNotification.Domain.Twilio;
using myNotification.Infrastructure.Twilio;
using Twilio;

namespace myNotification.Infrastructure.Service;

public static class InfrastructureService
{
    public static IServiceCollection AddWhatsAppInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var twilioSettings = config.GetSection("Twilio").Get<TwilioSettings>();
        TwilioClient.Init(twilioSettings.AccountSid, twilioSettings.AuthToken);

        services.AddScoped<IWhatsAppNotifier>(sp =>
            new TwilioWhatsAppNotifier(twilioSettings.FromNumber)
        );

        services.AddScoped<ISmsNotifier>(sp =>
            new SmsNotifier(twilioSettings.FromSmsNumber)
        );

        return services;
    }
}
