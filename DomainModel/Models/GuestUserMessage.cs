using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class GuestUserMessage
    {
        public int GuestUserMessageId { get; set; }
        public int GuestUserId { get; set; }
        public int MessageId { get; set; }
        public GuestUser GuestUser { get; set; }
        public Message Message { get; set; }

    }
}
