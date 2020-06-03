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
}
