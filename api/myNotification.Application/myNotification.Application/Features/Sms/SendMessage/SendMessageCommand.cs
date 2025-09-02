using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNotification.Application.Features.Sms.SendMessage
{
    public class SendSmsMessageCommand
    {
        public string MessageId { get; set; }

        public string Recipient { get; set; }

        public string ApproverName { get; set; }
    }
}
