using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDateTime { get; set; }

        public string CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public ApplicationUser Customer { get; set; }

        

        public int Amount { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
