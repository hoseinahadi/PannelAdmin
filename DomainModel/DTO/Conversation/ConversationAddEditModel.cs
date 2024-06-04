using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Conversation
{
    public class ConversationAddEditModel
    {
        public int ConversationId { get; set; }
        public bool isAccept { get; set; }
        public string Status { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
