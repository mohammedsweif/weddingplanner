using Final_project.Models.OurIdentity;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models.our_tables
{
    public class VenBudget
    {
        [Key,Column(Order =0)]
        
        public int catt_id { get; set; }

        [Key, Column(Order = 1)]
        public string vendor_id { get; set; }

        public int Cat_budget { get; set; }

        


    }
}
