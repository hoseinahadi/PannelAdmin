using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public string ImageCode { get; set; }
        public string Picture { get; set; }

        public List<SupplierImage> SupplierImages { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }

        public Image()
        {
            this.SupplierImages = new List<SupplierImage>();
        }

    }
}
