using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserFavoriteId { get; set; }
        public List<UserFavorite> UserFavorites { get; set; }
    }
}
