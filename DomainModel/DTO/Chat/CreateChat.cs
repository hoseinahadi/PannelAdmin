using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Chat
{
    public class CreateChat
    {
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
        [StringLength(512,ErrorMessage = " رعایت طول پیام ")]
        [Display(Name = " پیام ")]
        [Required(ErrorMessage = " پیام را وارد کنید ")]
        [DataType(DataType.MultilineText,ErrorMessage = " قالب پیام اشتباه است ")]
        public string Text { get; set; }
    }
}
