using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ConversationMessage
    {
        public int ConversationMessageId { get; set; }
        public int ConversationId { get; set; }
        public int MessageId { get; set; }

        public Message Message { get; set; }
        public Conversation Conversation { get; set; }
    }
}
