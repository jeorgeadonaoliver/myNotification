using Microsoft.AspNetCore.Mvc;
using myNotification.Application.Features.Sms.SendMessage;
using myNotification.Application.Features.WhatsApp.SendMessage;

namespace myNotification.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly SendWhatsAppMessage _sendWhatsAppMessage;
        private readonly SendSmsMessage _sendSmsMessage;


        public WhatsAppController(SendWhatsAppMessage sendWhatsAppMessage, SendSmsMessage sendSmsMessage)
        { 
            _sendWhatsAppMessage = sendWhatsAppMessage;
            _sendSmsMessage = sendSmsMessage;
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
