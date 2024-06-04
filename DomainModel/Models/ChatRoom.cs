using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class ChatRoom
    {
        
        public int ChatRoomId { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int SendUserId { get; set; }
        [ForeignKey(nameof(SendUserId))]
        public User sendingUser { get; set; }


        public int recaivingUserId { get; set; }
        [ForeignKey(nameof(recaivingUserId))]
        public User recaivingUser { get; set; }


        public virtual  List<Chat> chats { get; set; }
        public ChatRoom()
        {
            
            this.chats = new List<Chat>();
        }
    }
}
