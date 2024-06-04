using DomainModel.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.ChatRoom
{
    public class CreateChatRoom
    {
        public int SendingUserId { get; set; }
        public int ReceivingUserId { get; set; }
    }
}
