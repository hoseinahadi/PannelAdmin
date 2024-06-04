using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Conversation
{
    public class Chat
    {
        public int ConversationId { get; set; }
        public string UserName { get; set; }
        public string? EmployeeName { get; set; }
        public bool isAccept { get; set; }
        public List<Models.Message> Messages { get; set; }
    }
}
