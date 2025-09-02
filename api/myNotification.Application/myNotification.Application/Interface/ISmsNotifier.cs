using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myNotification.Application.Interface
{
    public interface ISmsNotifier
    {
        Task SendMessageAsync(string to, string message);
    }
}
