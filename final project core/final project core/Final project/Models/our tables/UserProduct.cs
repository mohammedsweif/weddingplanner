using Final_project.Models.our_tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class UserProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int piece_id { get; set; }
        [ForeignKey("ApplicationUser")]
        public string userseller_id { get; set; }
        [Required]
        public string Image { get; set; }
        public int piece_Cost { get; set; }
        public bool status { get; set; }
        [Required]
        public string piece_description { get; set; }
        [DataType(DataType.Date)]
        public DateTime publish_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime? available_date { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        //public List<UserSelled> userSelleds { get; set; }
    }
}
