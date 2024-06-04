using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.User
{
    public class UserSearchResult
    {
        public int UserId { get; set; }
        public int GenderId { get; set; }
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
        public List<Models.UserFavorite> UserFavorites { get; set; }
        public List<Models.Address> Addresses { get; set; }
        public List<Models.UserMessage> UserMessages { get; set; }
        public List<Models.Cart> Carts { get; set; }
        public List<Models.Order> Orders { get; set; }
        public List<Models.UserDiscount> UserDiscounts { get; set; }
        public List<Models.Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
