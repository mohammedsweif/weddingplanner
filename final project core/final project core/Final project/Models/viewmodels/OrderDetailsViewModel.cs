using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.viewmodels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
    }
    public class OrderDetailsViewModel
    {
        public int ProductID { get; set; }
        public int Qtu { get; set; }
        public int Price { get; set; }
    }
}
