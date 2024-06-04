using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public bool isAccept { get; set; }
        public string Status { get; set; }
        public int? EmployeeId { get; set; }
        public List<UserConversation> Users { get; set; }
        public List<ConversationMessage> ConversationMessages { get; set; }
        public Employee? Employee { get; set; }

        public Conversation()
        {
            this.ConversationMessages = new List<ConversationMessage>();
            this.Users = new List<UserConversation>();
        }
    }
}
