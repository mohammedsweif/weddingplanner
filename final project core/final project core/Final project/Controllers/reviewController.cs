using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class reviewController : ControllerBase
    {

        private readonly ProjectDbcontext _context;
        public reviewController(ProjectDbcontext context)
        {
            _context = context;
        }

       

        [HttpGet("Getureviews/{id}")]
        public IActionResult Getureviews(string id)
        {
            var x = _context.reviews.Where(a => a.Vendor_Id == id).Select(e => new
            {
                username = e.ApplicationUser.UserName,
                vendorname = e.Vendor.UserName,
                Comment = e.Comment,
                catname = e.catagory.cat_Name,
                PostDate = e.PostDate,
                User_Id = e.User_Id,
                Vendor_Id = e.Vendor_Id,
                catagory_id = e.catagory_id,
                ID = e.ID,
                liked = e.liked,
                replies = _context.review_Replays.Include(a=>a.ApplicationUser).Where(a=>a.Review_Id==e.ID).Select(q=>new {id=q.ID,reviewid=e.ID,userid=q.User_Id,uname =q.ApplicationUser.UserName,comment=q.Comment,liked=q.liked,postDate=q.PostDate, vendorid =e.Vendor_Id}).OrderByDescending(a => a.postDate).ToList()
                //.Where(a => a.Review_Id == e.ID).ToList() ToList()
                //   user =_context.review_Replays.FirstOrDefault(a => a.Review_Id == e.ID).ApplicationUser.UserName
            }).ToList();
            var y = x.OrderByDescending(e => e.PostDate);
            return Ok(y);
        }

        

        [HttpPost]
        [Route("Postreviews")]
        public ActionResult<Review> Postreviews([FromBody]Review n)
        {
            // n.PostDate = DateTime.Now;
            _context.reviews.Add(n);
            _context.SaveChanges();
            return Ok(n);
        }



    }
}