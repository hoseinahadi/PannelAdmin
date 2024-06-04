using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.DTO.Feature
{
    public class FeatureSearchResult
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public string FeatureValue { get; set; }
    }
}
