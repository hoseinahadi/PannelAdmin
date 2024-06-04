using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string LastPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime LastSeen { get; set; }
        public List<UserConversation> UserConversations { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }
        public List<Address> Addresses { get; set; }
        public List<UserMessage> UserMessages { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<UserDiscount> UserDiscounts { get; set; }
        public List<Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ChatRoom> sendingUserChatRoom { get; set; }
        public List<ChatRoom> recaivingUserChatRoom { get; set; }
        public List<Chat> Chats { get; set; }



        public User()
        {
            this.Addresses= new List<Address>();
            this.UserMessages=new List<UserMessage>();
            this.Carts=new List<Cart>();
            this.Orders=new List<Order>();
            this.UserDiscounts=new List<UserDiscount>();
            this.Images=new List<Image>();
            this.UserConversations = new List<UserConversation>();
            this.sendingUserChatRoom = new List<ChatRoom>();
            this.recaivingUserChatRoom = new List<ChatRoom>();
            this.Chats = new List<Chat>();
        }


    }
}
