using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
    public class RelatedProduct
    {
        public int RelatedProductID { get; set; }
        public int ProductID { get; set; }
        public int RelatedID { get; set; }
        public Product Product { get; set; }
        public Product Related { get; set; }
    }
}
