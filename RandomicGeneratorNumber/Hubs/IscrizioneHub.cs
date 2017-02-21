using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RandomicGeneratorNumber
{
    public class IscrizioneHub : Hub
    {
        public void Send(string nome, string cognome, string nomeFile)
        {
            Clients.Caller.addNewMessageToPage(nome, cognome, nomeFile);
        }
    }
}