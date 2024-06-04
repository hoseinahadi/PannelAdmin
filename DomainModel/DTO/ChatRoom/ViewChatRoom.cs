using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.DTO.Chat;
using DomainModel.DTO.User;

namespace DomainModel.DTO.ChatRoom
{
    public class ViewChatRoom
    {
        public int ChatId { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int SendingUserId { get; set; }
        public UserInfo SendingUser { get; set; }

        public int ReceivingUserId { get; set; }
        public UserInfo ReceivingUser { get; set; }

        public List<ViewChat> OldChat { get; set; }

    }
}
