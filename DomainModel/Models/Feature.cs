using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<CategoryFeature> CategoryFeatures { get; set; }

        public Feature()
        {
            this.ProductFeatures = new List<ProductFeature>();
            this.CategoryFeatures = new List<CategoryFeature>();
        }
    }
}
