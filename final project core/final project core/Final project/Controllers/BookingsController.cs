using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_project.Models;
using Final_project.Models.OurIdentity;

namespace Final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public BookingsController(ProjectDbcontext context)
        {
            _context = context;
        }
        //soaad 
        [HttpGet("GetBookings")]
        public ActionResult GetBookings()
        {
            var list = (from a in _context.booking
                        orderby a.BookDate descending
                        select new
                        {
                            VendorName = a.vendor.UserName,
                            a.user.UserName,
                            a.BookDate,
                            a.category.cat_Name,
                            a.Cost
                        }).Take(5);
            //var list = _context.booking.OrderByDescending(b => b.BookDate).Select(a => new
            //{
            //    VendorName = a.vendor.UserName,
            //    a.user.UserName,
            //    a.BookDate,
            //    a.category.cat_Name,
            //    a.Cost
            //});
            if (list != null)
            {
                return Ok(list);
            }

            else
            {
                return NotFound(new { msg = "not found" });
            }
        }
        [HttpGet("getByNumber/{x:int}")]
        public ActionResult getByNumber(int x)
        {
            var list = (from a in _context.booking
                        orderby a.BookDate descending
                        select new
                        {
                            VendorName = a.vendor.UserName,
                            a.user.UserName,
                            a.BookDate,
                            a.category.cat_Name,
                            a.Cost
                        }).Take(x);
            if (list != null)
            {
                return Ok(list);
            }

            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id}")]

        public ActionResult PutBooking(Booking newBooking)
        {
            Booking book = _context.booking.FirstOrDefault(a => a.BookingId == newBooking.BookingId);

            if (book != null)
            {
                book.BookDate = newBooking.BookDate;
                book.RealDate = newBooking.RealDate;
                book.CategoryId = newBooking.CategoryId;
                book.Status = newBooking.Status;
                book.Cost = newBooking.Cost;
                book.UserId = newBooking.UserId;
                book.VendorId = newBooking.VendorId;
                _context.SaveChanges();
                return Ok(newBooking);
            }
            else
            {
                return BadRequest(new { msg = "not found" });
            }

        }



        //end soaad

        


        // asmaa "bookingvendor"
        [HttpGet("Getbooking/{id}")]
        public IActionResult Getbooking(string id)
        {

            var x = _context.booking.Where(a => a.VendorId == id).Select(e => new
            {
                useremail = e.user.Email,
                userphone = e.user.PhoneNumber,
                username = e.user.UserName,
                BookingId = e.BookingId,
                BookDate = e.BookDate,
                RealDate = e.RealDate,
                CategoryId = e.CategoryId,
                Categoryname = e.category.cat_Name,
                Status = e.Status,
                Cost = e.Cost,
                UserId = e.UserId,
                VendorId = e.VendorId,

            }).ToList();
            var y = x.OrderByDescending(s => s.RealDate);
            return Ok(y);
        }

        //asmaa bookingvendor client details
        [HttpGet("GetClients/{id}")]
        public ActionResult GetClients(int id)
        {
            var x = _context.booking.Where(a => a.BookingId == id).Select(e => new
            {
                useremail = e.user.Email,
                userphone = e.user.PhoneNumber,
                username = e.user.UserName,
                BookingId = e.BookingId,
                BookDate = e.BookDate,
                RealDate = e.RealDate,
                CategoryId = e.CategoryId,
                Categoryname = e.category.cat_Name,
                Status = e.Status,
                Cost = e.Cost,
                UserId = e.UserId,
                VendorId = e.VendorId,
            }).FirstOrDefault();

            return Ok(x);
        }

        
    }
}
