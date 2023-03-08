using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public long UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<RelatedProduct> Products { get; set; }
        public ICollection<RelatedProduct> Relateds { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
        public Product()
        {
            this.Relateds=new List<RelatedProduct>();
            this.Products=new List<RelatedProduct>();
            this.ProductFeatures=new List<ProductFeature>();
            this.OrderDetails = new List<OrderDetails>();
        }

    }
}
