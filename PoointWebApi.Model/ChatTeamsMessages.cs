using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class ChatTeamsMessages
    {
        public int IdChatTeam { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
        public int Encryptado { get; set; }
    }

    public class ChatTeamsMessagesData
    {
        public string User { get; set; }
        public string Message { get; set; }
        public int Encryptado { get; set; }
    }

    public class ChatTeamsMessagesId
    {
        public int IdChatTeam { get; set; }
    }
}
