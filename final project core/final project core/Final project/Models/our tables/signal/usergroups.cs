using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables.signal
{
    public class UserGroups
    {
        [Key]
        public int id { get; set; }
        public string groupname { get; set; }
        [ForeignKey("users")]
        public string userId { get; set; }
        public  ApplicationUser  users { get; set; }
    }
}
