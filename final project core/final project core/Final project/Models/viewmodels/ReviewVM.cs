using Final_project.Models.our_tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class ReviewVM
    {
        public int Id { get; set; }
        public string comment { get; set; }
        public string category { get; set; }
        public string Vendor { get; set; }
        public string Date { get; set; }
        public string image { get; set; }
        public int catid { get; set; }

    }
    public class VendorVM
    {
        
        public string vendorname { get; set; }
        public string instgram { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string image { get; set; }
        public string cat { get; set; }

    }
    public class ClientVM
    {

        public string vendor_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }
        public string cat_name { get; set; }
        public int cat_id { get; set; }
        public string book_date { get; set; }
        public string real_date { get; set; }
        public bool status { get; set; }
        public int bookingid { get; set; }
        public string user_id { get; set; }
        public string image { get; set; }


    }
    public class work
    {
        public string image { get; set; }

    }
}
