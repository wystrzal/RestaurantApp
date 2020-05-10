using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Messaging.SignalR
{
    public class SignalServerHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveOrder");
        }
    }
}
