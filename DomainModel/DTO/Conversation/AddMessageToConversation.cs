using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Conversation
{
    public class AddMessageToConversation
    {
        public int conversationId { get; set; }
        public string message { get; set; }
        public string UserName { get; set; }
        public string? EmployeeName { get; set; }

    }
}
