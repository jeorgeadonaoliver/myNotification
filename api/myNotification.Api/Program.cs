using FluentValidation;
using myNotification.Application.Features.Sms.SendMessage;
using myNotification.Application.Features.WhatsApp;
using myNotification.Application.Features.WhatsApp.SendMessage;
using myNotification.Domain.WhatsApp;
using myNotification.Infrastructure.Service;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.MapControllers();

app.Run();
