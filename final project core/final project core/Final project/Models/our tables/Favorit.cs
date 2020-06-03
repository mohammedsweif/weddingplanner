using Final_project.Models.OurIdentity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class Favorit
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("user")]
        public string user_id { get; set; }
        [ForeignKey("vendor")]
        public string vendor_id { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string vendor_Name { get; set; }
        public string image { get; set; }
        public string about { get; set; }
        [ForeignKey("catagory")]

        public int cat_id { get; set; }
        public ApplicationUser vendor { get; set; }
        public catagory catagory { get; set; }
        public ApplicationUser user { get; set; }
        //  public List<Favorit_user> favorit_Users { get; set; }

    }
}
