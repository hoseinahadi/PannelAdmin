using DomainModel.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Chat
{
    public class ViewChat
    {
        public int ChatId { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
        public UserInfo User { get; set; }
        public string Text { get; set; }
        public string CreationDatestring { get; set; }
    }
}
