using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Message
{
    public class MessageNotRead
    {
        public int messageId { get; set; }
        public string messageHeader { get; set; }
        public string messageBody { get; set; }
        public string userName { get; set; }
        public string Status { get; set; }
        public DateTime MessageTime { get; set; }
    }
}
