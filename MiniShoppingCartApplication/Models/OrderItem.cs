using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Models
{
    public class OrderItem
    {
        [Key, Column(Order = 0)]
        public int OrderID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductID { get; set; }
        [ForeignKey("OrderID")]
        public virtual CustomerOrder CustomerOrders { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public int Quantity {get; set;}
    }
}
