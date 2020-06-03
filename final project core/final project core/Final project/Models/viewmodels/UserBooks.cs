using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.viewmodels
{
    public class UserBooks
    {
        public string vendor_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public string book_date { get; set; }
        public string user_id { get; set; }
        public int cost { get; set; }
        public bool flag { get; set; }

        public int book_id { get; set; }
        public string realdate { get; set; }
        public bool status { get; set; }
    }
}
