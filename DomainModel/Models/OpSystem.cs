using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class OpSystem
    {
        public int OpSystemId { get; set; }
        public string OpName { get; set; }
        public List<GuestUser> GuestUsers { get; set; }

        public OpSystem()
        {
            this.GuestUsers = new List<GuestUser>();
        }
    }
}
