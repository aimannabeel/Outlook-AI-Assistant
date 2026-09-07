using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookAddIn1
{
    public class ChatSession
    {
        public List<ChatMessage> ChatMessageHistory { get; set; }

        public ChatSession()
        {
            ChatMessageHistory = new List<ChatMessage>();
        }
    }
}
