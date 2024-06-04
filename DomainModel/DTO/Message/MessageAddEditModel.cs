using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Message
{
    public class MessageAddEditModel
    {
        public int MessageId { get; set; }
        [Required(ErrorMessage = " متن نامه را بنویسید ")]
        [Display(Name = " متن نامه ")]
        public string MessageBody { get; set; }
        [Required(ErrorMessage = " تیتر نامه را بنویسید ")]
        [Display(Name = " تیتر نامه ")]
        public string MessageHeader { get; set; }
        public bool Read { get; set; }
        public DateTime MessageTime { get; set; }

        public string Target { get; set; }

    }
}
