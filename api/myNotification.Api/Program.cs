using myNotification.Application.Features.Sms.SendMessage;
using myNotification.Application.Features.WhatsApp.SendMessage;
using myNotification.Infrastructure.Hubs;
using myNotification.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();


// Infrastructure
builder.Services.AddWhatsAppInfrastructure(builder.Configuration);

builder.Services.AddScoped<SendWhatsAppMessage>();
builder.Services.AddScoped<SendSmsMessage>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<NotificationHub>("/notification");

app.MapControllers();

app.Run();
