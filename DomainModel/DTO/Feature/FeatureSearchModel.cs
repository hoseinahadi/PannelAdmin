using DomainModel.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Feature
{
    public class FeatureSearchModel : PageModel
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }

    }
}
