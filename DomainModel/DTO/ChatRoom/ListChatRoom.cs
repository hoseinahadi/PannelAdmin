using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Assist;

namespace DomainModel.DTO.ChatRoom
{
    public class ListChatRoom : PageModel
    {
        public List<ViewChatRoom>? list { get; set; }
        public int? SendingUserId { get; set; }
        public int? recaivingUserId { get; set; }


    }
}
