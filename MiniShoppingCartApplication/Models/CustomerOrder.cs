using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Models
{
    public class CustomerOrder
    {
        [Key]
        public int CustomerOrderID { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public int? CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
    }
}
