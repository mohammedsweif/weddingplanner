using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class season
    {
        [Key]
        public int season_id { get; set; }
        public string season_name { get; set; }
        /// <asmaa>
        public string start_time { get; set; }
        public string period { get; set; }
        
        public List<Package> packages { get; set; }
    }
}
