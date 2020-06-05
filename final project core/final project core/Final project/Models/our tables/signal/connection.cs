using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables.signal
{
    public class Connection
    {
        [Key]
        public int  id { get; set; }
        public string  connectionId { get; set; }
        [ForeignKey("user")]
        public string userid { get; set; }
        public ApplicationUser user { get; set; }
    }
}
