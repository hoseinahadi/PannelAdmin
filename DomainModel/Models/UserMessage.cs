using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public User User { get; set; }
    }
}
