using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myNotification.Application.Features.WhatsApp;
using myNotification.Application.Features.WhatsApp.SendMessage;
using myNotification.Domain;
using myNotification.Domain.WhatsApp;

namespace myNotification.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly SendWhatsAppMessage _sendWhatsAppMessage;


        public WhatsAppController(SendWhatsAppMessage sendWhatsAppMessage)
        { 
            _sendWhatsAppMessage = sendWhatsAppMessage;
        }


        [HttpPost("send")] // POST /api/whatsapp/send
        public async Task<ActionResult> Send([FromBody] SendMessageCommand command, CancellationToken ct)
        {
            return Ok(await _sendWhatsAppMessage.SendMessage(command));
        }
    }
}
