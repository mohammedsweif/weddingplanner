using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.OurIdentity
{
    public class UserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime? birth_date { get; set; }
        [Required]
        public  string addr{ get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }

    }
}
