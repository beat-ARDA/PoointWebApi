using System;
using System.Collections.Generic;
using System.Text;

namespace PoointWebApi.Model
{
    public class ChatMessage
    {
        public int IdChat { get; set; }
        public string Message { get; set; }
        public string User { get; set; }
    }
    public class ChatMessageData
    {
        public string User { get; set; }
        public string Message { get; set; }
    }

    public class ChatMessageId
    {
        public int IdChat { get; set; }
    }
}
