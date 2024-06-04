using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageBody { get; set; }
        public string MessageHeader { get; set; }
        public bool Read { get; set; }
        public DateTime MessageTime { get; set; }

        public List<ConversationMessage> ConversationMessages { get; set; }
        public List<UserMessage> UserMessages { get; set; }
        public List<OrderMessage> OrderMessages { get; set; }
        public List<GuestUserMessage> GuestUserMessages { get; set; }
        public List<OrderReturnMessage> OrderReturnMessages { get; set; }
        public List<EmployeeMessage> EmployeeMessages { get; set; }

        public Message()
        {
            this.UserMessages=new List<UserMessage>();
            this.OrderMessages=new List<OrderMessage>();
            this.EmployeeMessages = new List<EmployeeMessage>();
            this.GuestUserMessages = new List<GuestUserMessage>();
            this.OrderReturnMessages = new List<OrderReturnMessage>();
            this.ConversationMessages = new List<ConversationMessage>();
        }

    }
}
