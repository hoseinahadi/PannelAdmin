using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OrderMessage
    {
        public int OrderMessageId { get; set; }
        public int OrderId { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public Order Order { get; set; }
    }
}
