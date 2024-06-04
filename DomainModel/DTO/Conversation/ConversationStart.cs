using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Conversation
{
    public class ConversationStart
    {
        public string UserName { get; set; }
        public string MessageHeader { get; set; }
        public string MessageBody { get; set; }
        public string UserFullName { get; set; }


    }
}
