using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
  // public enum season {winter,summer,spring, Autumn };
  //llldldlldlldllldldldldldldl
    public class Event
    {
        public int id { get; set; }
        public string Event_name { get; set; }
        public List<Package> packages { get; set; }

    }
   
}
