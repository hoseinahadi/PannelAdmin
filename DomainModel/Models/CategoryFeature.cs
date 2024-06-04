using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class CategoryFeature
    {
        public int CategoryFeatureId { get; set; }
        public int FeatureId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Feature Feature { get; set; }

    }
}
