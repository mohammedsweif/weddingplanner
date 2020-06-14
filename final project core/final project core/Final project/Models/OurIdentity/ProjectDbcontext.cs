using Final_project.Models.our_tables;
using Final_project.Models.our_tables.signal;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class ProjectDbcontext:IdentityDbContext<ApplicationUser>
    {
        public ProjectDbcontext(DbContextOptions<ProjectDbcontext> options):base(options)
        {
         
        }

        public DbSet<UserGroups> users { get; set; }
        public DbSet<Connection> connections { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Booking> booking { get; set; }
        public DbSet<catagory> catagories { get; set; }
        public DbSet<Favorit> favorits { get; set; }
        public DbSet<Messages> messages { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<UserProduct> userProducts { get; set; }
        public DbSet<UserSelled> userSelleds { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<VendorBusy> vendorBusies { get; set; }
        public DbSet<VendorWorks> vendorWorks { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<season> seasons { get; set; }
        public DbSet<VenBudget> venBudgets { get; set; }
        public DbSet<Review_replays> review_Replays { get; set; }
        public DbSet<toDo> toDo { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<productType> ProductTypes { get; set; }
        public DbSet<shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        //  public DbSet<bookrelation_user> books { get; set; }
        //  public DbSet<Favorit_user> favorit_Users { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VenBudget>().HasKey(ba => new { ba.vendor_id, ba.catt_id });
            builder.Entity<Booking>().HasOne(e => e.Package).WithMany(e => e.Bookings)
                .OnDelete(DeleteBehavior.NoAction);
        }

       




    }
    //this class for increase more details about every user
    public class ApplicationUser : IdentityUser
    {
   
      //  [StringLength(maximumLength:150)]
        public string address { get; set; }
        // [DataType(DataType.Date)]

        //  public  List<bookrelation_user> books { get; set; }
       
        public string ImageUrl { get; set; }

        public DateTime? birth_date { get; set; }
        public string Gender { get; set; }
        public string BioInformation { get; set; }
        public List<Article> articles { get; set; }
       

     //   public List<Booking> Bookings { get; set; }

    //    public List<Favorit> favorits { get; set; }
     //   public List<Messages> messages { get; set; }
      //  public List<Package> packages { get; set; }
      //  public List<Rating> ratings { get; set; }
      //  public List<Review> reviews { get; set; }
        public List<UserProduct> userUseds { get; set; }
      //  public List<UserSelled> userSelleds { get; set; }
        public List<Vendor> vendors { get; set; }
        public List<VendorWorks> vendorWorks { get; set; }
        public List<VendorBusy> vendorBusies { get; set; }
        //   public List<Favorit_user> favorit_Users { get; set; }
        public List<UserGroups> userGroups { get; set; }
        public Connection connection { get; set; }


    }
}
