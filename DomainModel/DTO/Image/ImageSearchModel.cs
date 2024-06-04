using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Image
{
    public class ImageSearchModel : PageModel
    {
        public int ImageId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public string ImageCode { get; set; }
        public string Picture { get; set; }

    }
}
