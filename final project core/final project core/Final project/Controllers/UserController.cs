using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Security.Cryptography;
using Final_project.Models.our_tables;
using Microsoft.AspNetCore.Identity;
using Final_project.Models.viewmodels;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        private static IWebHostEnvironment environment;
        private readonly IHttpContextAccessor contextAccessor;

        public UserController(ProjectDbcontext context,IWebHostEnvironment _environment,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            environment = _environment;
            this.contextAccessor = contextAccessor;
        }


        [HttpGet]
        [Route("ClientBooks/{id}")]
        public ActionResult GetClientBooks(string id)
        {

            List<UserBooks> userBooks = new List<UserBooks>();
            foreach (var i in _context.booking.Where(a => a.UserId == id).Select(e => new
            {
                vendor_id = e.VendorId,
                name = e.vendor.UserName,
                phone = e.vendor.PhoneNumber,
                Address = e.vendor.address,
                book_date = e.BookDate.ToString("dddd, dd MMMM yyyy"),
                user_id = e.UserId,
                cost = e.Cost,
                book_id = e.BookingId,
                flag = false,
                status = e.Status

            }).ToList())
            {
                userBooks.Add(new UserBooks
                {
                    Address = i.Address,
                    name = i.name,
                    phone = i.phone,
                    vendor_id = i.vendor_id,
                    book_date = i.book_date,
                    user_id = i.user_id,
                    cost = i.cost,
                    flag = i.flag,
                    book_id = i.book_id,
                    status = i.status
                });
            }
            DateTime now = DateTime.Now;
            DateTime yesterday = now.AddDays(-1);
            foreach (var i in userBooks)
            {
                int n = DateTime.Parse(i.book_date).Year;
                int m = DateTime.Parse(i.book_date).Month;
                //if (DateTime.Parse(i.book_date).Day - DateTime.Parse(i.realdate).Day <= 1)
                if ((i.status == true && DateTime.Parse(i.book_date) > yesterday && DateTime.Parse(i.book_date)<=now) || i.status == false || m != now.Month || n !=now.Year  )
                {
                    i.flag = true;
                }

            }
            if (userBooks != null)

            {
                return Ok(userBooks);
            }

            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
            //if(user == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    UserViewModel userSelected = new UserViewModel();
            //    userSelected.Id = user.Id;
            //    userSelected.addr = user.address;
            //    userSelected.birth_date =  (DateTime)user.birth_date;
            //    userSelected.PhoneNumber = user.PhoneNumber;

            //    return userSelected;
            //}

        }
        [HttpGet]
        [Route("Getuse/{id}")]
        public async Task<ActionResult> getallusers(string id)
        {
            var user = await _context.Users.FindAsync(id);
            user.ImageUrl = Process(user.ImageUrl);
            return Ok(user);
        }
        [HttpPost]
        [Route("EditUser")]
        public async Task<ActionResult> PutUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {

                var selectedUser = await _context.Users.FindAsync(user.Id);
                if (selectedUser != null)
                {
                    selectedUser.Id = user.Id;
                    selectedUser.address = user.addr;
                    selectedUser.birth_date = user.birth_date;
                    selectedUser.PhoneNumber = user.PhoneNumber;
                    selectedUser.BioInformation = user.Bio;
                    await _context.SaveChangesAsync();
                    return Ok("edit");
                }

            }
            return NoContent();
        }
        [HttpPost]
        [Route("deleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetPackage/{id}")]
        public async Task<ActionResult> GetPackage(string id)
        {
            var packages = await _context.packages.Include(a => a.catagory).Include(a => a.ApplicationUser).Where(a => a.VendorId == id).Include(a => a.Event).Select(a => new
            {
                VendorId = a.VendorId,
                VendorName = a.ApplicationUser.UserName,
                PackageId = a.PackageId,
                PackageName = a.feature_name,
                Description = a.description,
                Cost = a.PackageCost,
                CategoryId = a.catagory_id,
                CategoryName = a.catagory.cat_Name,
                EventId = a.Event_id,
                Event = a.Event.Event_name,
                Address = a.ApplicationUser.address,

            }).ToListAsync();
            if (packages != null)
            {
                return Ok(packages);
            }
            else
            {
                return NotFound("there is no Packages");
            }
        }

        [HttpGet]
        [Route("GetDaysBlocked/{id}")]
        public async Task<ActionResult> GetDaysBlocked(string id)
        {

            List<string> Dates = new List<string>();
            var dates = await _context.vendorBusies.Where(a => a.vendor_id == id).Select(a => new { BusyDate = a.BusyDay.ToString("yyyy-MM-dd") }).ToListAsync();
            if (dates != null)
            {
                
                return Ok(dates);
            }
            else
            {
                return NotFound("No Date");
            }
        }
        [HttpPost]
        [Route("AddBook")]
        public async Task<ActionResult> AddBook(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.BookDate = DateTime.Now;
                await _context.booking.AddAsync(booking);
                await _context.SaveChangesAsync();
                VendorBusy vendorBusy = new VendorBusy();
                vendorBusy.vendor_id = booking.VendorId;
                vendorBusy.BusyDay = booking.RealDate;
                vendorBusy.Reason = "Book For " + booking.UserId;
                vendorBusy.BookingId = booking.BookingId;
                await _context.vendorBusies.AddAsync(vendorBusy);
                await _context.SaveChangesAsync();
                return Ok(new { BusyDate = booking.RealDate.ToString("yyyy-MM-dd") });
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        [Route("GetSpecificPackage/{id}")]
        public async Task<ActionResult> GetSpecificPackage(int id)
        {
            var package = await _context.packages.Include(a => a.catagory).Include(a => a.ApplicationUser).Where(a => a.PackageId == id).Include(a => a.Event).Select(a => new
            {
                VendorId = a.VendorId,
                VendorName = a.ApplicationUser.UserName,
                PackageId = a.PackageId,
                PackageName = a.feature_name,
                Description = a.description,
                Cost = a.PackageCost,
                CategoryId = a.catagory_id,
                CategoryName = a.catagory.cat_Name,
                EventId = a.Event_id,
                Event = a.Event.Event_name,
                Address = a.ApplicationUser.address,

            }).FirstAsync();
            if (package != null)
            {
                return Ok(package);

            }
            else
            {
                return NotFound("there is no package");
            }
        }
        [HttpGet]
        [Route("GetBooking/{id}")]
        public async Task<ActionResult> GetBooking(string id)
        {
            var BookingList = await _context.booking.Include(a => a.vendor).Include(a => a.category).Where(a => a.UserId == id && a.RealDate >= DateTime.Now).Select(x => new {
                Id = x.BookingId,
                BookDate = x.BookDate,
                RealDate = x.RealDate,
                status = x.Status,
                vendorname = x.vendor.UserName,
                category = x.category.cat_Name,
                cost = x.Cost
            }).ToListAsync();
            if (BookingList != null)
            {
                return Ok(BookingList);
            }
            else
            {
                return NotFound("there is no Booking");
            }
        }
        [HttpGet]
        [Route("AllReviews/{id}")]
        public async Task<ActionResult> GetAllReviews(string id)

        {

            ApplicationUser user = _context.Users.Find(id);
            List<ReviewVM> reviewVMs = await _context.reviews.Where(a => a.User_Id == id).Include(a => a.Vendor).Include(a => a.catagory).Select(a => new ReviewVM
            {
                Id = a.ID,
                comment = a.Comment,
                catid = a.catagory_id,
                category = a.catagory.cat_Name,
                Date = a.PostDate.ToString("yyyy-MM-dd"),
                Vendor = a.Vendor.UserName,
                image = a.Vendor.ImageUrl
            }).ToListAsync();
            for (int i = 0; i < reviewVMs.Count; i++)
            {
                reviewVMs[i].image = Process(reviewVMs[i].image);

            }
            return Ok(reviewVMs);
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            var review = await _context.reviews.FindAsync(id);
            if (review != null)
            {
                _context.reviews.Remove(review);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("CancelBooking/{id}")]
        public async Task<ActionResult> CancelBook(int id)
        {
            Booking book = await _context.booking.FindAsync(id);
            if (book != null)
            {
                DateTime datenow = DateTime.Now;
                DateTime BookDate = book.RealDate;

                double NumberOfDates = (BookDate - datenow).TotalDays;
                if (NumberOfDates > 10)
                {

                    var BusDate = await _context.vendorBusies.Where(a => a.BookingId == book.BookingId).SingleAsync();
                    _context.booking.Remove(book);
                    _context.vendorBusies.Remove(BusDate);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound("you can't Cancel Booking ");
                }
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        [Route("EditBook")]
        public async Task<ActionResult> EditBook(Booking booking)
        {
            Booking Book = await _context.booking.FindAsync(booking.BookingId);
            if (Book != null)
            {
                DateTime DateNow = DateTime.Now;
                DateTime RealDate = Book.RealDate;
                double NOofDays = (RealDate - DateNow).TotalDays;
                if (NOofDays > 10)
                {
                    Book.RealDate = booking.RealDate;
                    //   _context.Entry(booking).State = EntityState.Modified;
                    VendorBusy BusyDate = await _context.vendorBusies.Where(a => a.BookingId == booking.BookingId).SingleAsync();
                    BusyDate.BusyDay = booking.RealDate;
                    await _context.SaveChangesAsync();
                    return Ok(new { BusyDate = booking.RealDate.ToString("yyyy-MM-dd") });
                }
                else
                {
                    return NotFound("you can not Edit your");
                }
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        [Route("GetSpecficBook/{id}")]
        public async Task<ActionResult> GetSpecficBook(int id)
        {
            var SelectedBook = await _context.booking.Where(a => a.BookingId == id).Include(a => a.user).Include(a => a.category).Include(a => a.vendor).Select(a => new {
                a.vendor.address,
                a.vendor.Email,
                a.vendor.PhoneNumber,
                a.VendorId,
                a.UserId,
                a.RealDate,
                a.Cost,
                a.BookingId,
                a.category.cat_Name,
                a.BookDate,
                a.Status,
                a.pack_id,
                a.CategoryId
            }).FirstOrDefaultAsync();
            if (SelectedBook != null)
            {
                return Ok(SelectedBook);
            }
            else
            {
                return NotFound();

            }

        }
        [HttpGet]
        [Route("GetallFavorit/{id}")]
        public async Task<ActionResult> GetAllFavorit(string id)
        {
            List<FavoritVM> listfavorit = await _context.favorits.Where(a => a.user_id == id).Include(a => a.vendor).Include(a => a.catagory).Select(a => new FavoritVM
            {
                VendorName = a.vendor.UserName,
                category = a.catagory.cat_Name,
                Phone = a.vendor.PhoneNumber,
                address = a.vendor.address,
                PostDate = a.date.ToString("yyyy-MM-dd"),
                image = a.vendor.ImageUrl,
                Id = a.Id
            }).ToListAsync();
            for (int i = 0; i < listfavorit.Count; i++)
            {
                listfavorit[i].image = Process(listfavorit[i].image);
            }
            return Ok(listfavorit);
        }
        [HttpDelete]
        [Route("RemovefromFavorit/{id}")]
        public async Task<ActionResult> RemoveFromFavorit(int id)
        {
            var Fav_vend = await _context.favorits.FindAsync(id);
            if (Fav_vend != null)
            {
                _context.favorits.Remove(Fav_vend);
                await _context.SaveChangesAsync();
                return Ok("deleted");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage(ImageVM imageVM)
        {
            var user = await _context.Users.FindAsync(imageVM.id);
            if (user != null)
            {
                string image = ConvertImage(imageVM.Imageurl);
                user.ImageUrl = image;
                await _context.SaveChangesAsync();
                return Ok(new { Imagesrc = user.ImageUrl });
            }
            else
            {
                return NotFound();
            }

        }
        public static string ConvertImage(string ImageUrl)
        {

            string ImageProcess = ImageUrl.Split("base64,")[1];
            byte[] by = Convert.FromBase64String(ImageProcess);

            ImageConverter imageConverter = new ImageConverter();
            Image image = (Image)imageConverter.ConvertFrom(by);
            string extension = ".png";
            string Name = Guid.NewGuid().ToString() + extension;
            string fullpath = Path.Combine(environment.WebRootPath, "images", Name);
            image.Save(fullpath);
            return Name;
        }
        private string Process(string Image)
        {
            //get domain name;
            var request = this.contextAccessor.HttpContext.Request;
            //make path for Image   
            string path = $"{request.Scheme}://{request.Host.Value}/images/{Image}";
            return path;
        }


        [HttpDelete("{id}")]
        
        public ActionResult deleteBooking(int id)    ////////busy @vendor 
        {
           var book= _context.booking.FirstOrDefault(a => a.BookingId == id);
            if (book == null)
            {
                return NotFound();
            }

            else
            {
                _context.booking.Remove(book);
                _context.SaveChanges();

                var busy = _context.vendorBusies.FirstOrDefault(n => n.BookingId == book.BookingId && n.BusyDay == book.RealDate && n.vendor_id == book.VendorId && book.Status == true);
                if (busy != null)
                {
                    _context.vendorBusies.Remove(busy);
                    _context.SaveChanges();
                }
                
                
                return Ok(book);
            }
            
        }




    }
}