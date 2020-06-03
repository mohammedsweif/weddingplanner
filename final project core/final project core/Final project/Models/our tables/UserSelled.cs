using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class UserSelled
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("useseller")]
        public string userseller_id { get; set; }
        [ForeignKey("userbuyer")]
        public string userbuyer_id { get; set; }
        [ForeignKey("userSelled")]
        public int user_used { get; set; }
        public int cost { get; set; }
        public DateTime date { get; set; }
         
        public ApplicationUser useseller { get; set; }
        

        public ApplicationUser userbuyer { get; set; }
       // public UserSelled userSelled { get; set; }

    }
}
