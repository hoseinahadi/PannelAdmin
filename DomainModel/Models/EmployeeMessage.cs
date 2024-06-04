using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class EmployeeMessage
    {
        public int EmployeeMessageId { get; set; }
        public int EmployeeId { get; set; }
        public int MessageId { get; set; }
        public Employee Employee { get; set; }
        public Message Message { get; set; }

    }
}
