using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public String FeatureName { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public ICollection<CategoryFeature> CategoryFeatures { get; set; }
        public Feature()
        {
            this.ProductFeatures = new List<ProductFeature>();
            this.CategoryFeatures = new List<CategoryFeature>();
        }
    }
}