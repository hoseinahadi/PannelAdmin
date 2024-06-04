
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DomainModel.Models
{
    public class Chat
    {
        public int ChatId { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int? ChatRoomId { get; set; }
        [ForeignKey(nameof(ChatRoomId))]
        public ChatRoom? ChatRoom { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [MaxLength(512)]
        public string Text { get; set; }
    }
}
