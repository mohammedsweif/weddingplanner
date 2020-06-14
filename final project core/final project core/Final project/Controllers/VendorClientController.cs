using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendorClientController : ControllerBase
    {
        ProjectDbcontext _context;
        public VendorClientController(ProjectDbcontext context)
        {
            _context = context;
        }

        [HttpGet("bookingbyId/{id}")]
        public ActionResult GetbookingbyId(int id)
        {
            var One = _context.booking.Where(a => a.BookingId == id).Select(e => new
            {
               
                vendor_id = e.VendorId,
                name = e.vendor.UserName,
                email = e.vendor.Email,
                phone = e.vendor.PhoneNumber,
                Address = e.vendor.address,
                cat_name = e.category.cat_Name,
                cat_id = e.CategoryId,
                book_date = e.BookDate.ToString("dddd, dd MMMM yyyy"),
                real_date = e.RealDate.ToString("dddd, dd MMMM yyyy"),
                status = e.Status,
                bookingid = e.BookingId,
                user_id = e.UserId,
                cost=e.Cost

            }).FirstOrDefault();
            return Ok(One);
        }


        [HttpPost]
        [Route("addReplay")]
        public IActionResult addReplay( Review_replays n)
        {
            _context.review_Replays.Add(n);
            _context.SaveChanges();
            return Ok(n);
        }


        [HttpGet("getVenClients/{id}")]
        public ActionResult GetVendorClients(string id)
        {
            List<VendorClientViewModel> model = new List<VendorClientViewModel>();
            List<Booking> list = new List<Booking>();
            var lists = _context.booking.Where(a => a.VendorId == id).Select(e => new
            {
                id=e.UserId,
                name = e.user.UserName,
                email = e.user.Email,
                phone = e.user.PhoneNumber,
                status = e.Status,
                cat_name = e.category.cat_Name,
                cat_id = e.CategoryId


            });
            if(lists != null)
            {
                return Ok(lists);
            }

            else
            {
                return NotFound();
            }
             
        }


        [HttpGet("getClientVen/{id}")]
        public ActionResult GetClientVen(string id)
        {
            List<Booking> distinctList = new List<Booking>();
            List<Booking> list = new List<Booking>();
            var lists = _context.booking.Where(a => a.UserId == id).Select(e => new
            {



                vendor_id = e.VendorId,
                name = e.vendor.UserName,
                email = e.vendor.Email,
                phone = e.vendor.PhoneNumber,
                Address = e.vendor.address,
                cat_name = e.category.cat_Name,
                cat_id = e.CategoryId,
                book_date = e.BookDate.ToString("dddd, dd MMMM yyyy"),
                real_date = e.RealDate.ToString("dddd, dd MMMM yyyy"),
                status = e.Status,
                bookingid = e.BookingId,
                user_id=e.UserId

            }).ToList().OrderBy(a=>a.book_date).GroupBy(a=>a.vendor_id).Select(a=>a.FirstOrDefault());
           



            if (lists != null)
            {
                return Ok(lists);
            }

            else
            {
                return NotFound();
            }

        }

        [HttpGet("GetRate/{id}")]
        public ActionResult GetRate(string id)
        {
            List<Rating> rate = new List<Rating>();
            List<Rating> disrate = new List<Rating>();

            rate = _context.ratings.Where(a => a.User_Id == id ).ToList();
            
            return Ok(rate);
        }


        [HttpGet("GetVenUserCategories/{id}")]
       public ActionResult GetVenUserCategories(string id)
        {
            List<Booking> distinctList = new List<Booking>();
            List<int> cats = new List<int>();
            List<catagory> categs = new List<catagory>();
            List<Booking> list = new List<Booking>();
            list = _context.booking.Where(a => a.UserId == id).ToList();
            foreach(var i in list)
            {
                cats.Add(i.CategoryId);
            }
           
            foreach(var c in cats)
            {
                categs.Add(_context.catagories.FirstOrDefault(a => a.cat_Id == c));

                
            }



            if (categs != null)
            {
                return Ok(categs.Distinct());
            }

            else
            {
                return NotFound();
            }
        }

    }

    
}