using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserID { get; set; }
        // public User User { get; set; }
        /// <summary>
        /// Before Check out false After checkout true
        /// </summary>
        public bool OrderStatus { get; set; }
        public string OrderDescription { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public Order()
        {
            this.OrderDetails = new List<OrderDetails>();
        }
    }
}
