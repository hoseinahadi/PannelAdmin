using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderReturnMessage
    {
        public int OrderReturnMessageId { get; set; }
        public int OrderReturnId { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }

        public OrderReturn OrderReturn { get; set; }
    }
}
