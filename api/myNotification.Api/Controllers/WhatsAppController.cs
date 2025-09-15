using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using myNotification.Application.Features.Sms.SendMessage;
using myNotification.Application.Features.WhatsApp.SendMessage;
using myNotification.Infrastructure.Hubs;

namespace myNotification.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly SendWhatsAppMessage _sendWhatsAppMessage;
        private readonly SendSmsMessage _sendSmsMessage;
        private readonly IHubContext<NotificationHub> _hubContext;

        public WhatsAppController(SendWhatsAppMessage sendWhatsAppMessage, SendSmsMessage sendSmsMessage, IHubContext<NotificationHub> hubContext)
        { 
            _sendWhatsAppMessage = sendWhatsAppMessage;
            _sendSmsMessage = sendSmsMessage;
            _hubContext = hubContext;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> SendNotification(string userId, [FromBody] string message)
        {
            await _hubContext.Clients.Group(userId).SendAsync("ReceiveNotification", message);
            return Ok(new { status = "sent", user = userId, message });
        }


        [HttpPost("sendWhatsapp")] // POST /api/whatsapp/send
        public async Task<ActionResult> SendWhatsapp([FromBody] SendWhatsAppMessageCommand command, CancellationToken ct)
        {
            return Ok(await _sendWhatsAppMessage.SendMessage(command));
        }

        [HttpPost("sendSms")] // POST /api/whatsapp/send
        public async Task<ActionResult> SendSms([FromBody] SendSmsMessageCommand command, CancellationToken ct)
        {
            return Ok(await _sendSmsMessage.SendMessage(command));
        }
    }
}
