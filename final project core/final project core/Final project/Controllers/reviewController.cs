﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                ID = e.ID
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