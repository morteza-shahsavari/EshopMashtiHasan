using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public double Grade { get; set; }
        public string Tel { get; set; }
        public ICollection<Product> Products { get; set; }
        public Supplier()
        {
            this.Products=new List<Product>();
        }
    }
}
