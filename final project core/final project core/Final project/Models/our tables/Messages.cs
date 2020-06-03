using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Mess_Text { get; set; }
        public string Replay { get; set; }
        [ForeignKey("vendor")]
        public string Vendor_id { get; set; }
        [ForeignKey("user")]
        public string User_id { get; set; }
        public DateTime Date_Send { get; set; }
        public DateTime Date_replay { get; set; }
        public ApplicationUser vendor { get; set; }
        public ApplicationUser user { get; set; }

    }

}
