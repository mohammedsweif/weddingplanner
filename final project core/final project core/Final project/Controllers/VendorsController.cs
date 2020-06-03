using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using System.Composition.Convention;
using Microsoft.AspNetCore.Identity;

namespace Final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class VendorsController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public VendorsController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> Getvendors()
        {
            
            
            return await _context.vendors.ToListAsync();
        }

        //[HttpGet]
        //[Route("GetVendor/{id}")]
        //public async Task<ActionResult> GetVendor(string id)
        //{
        //    var Vendor = await _context.Users.FindAsync(id);
        //    if(Vendor == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(Vendor);
        //}
        [HttpPost]
        [Route("postvendor")]
        public async Task<ActionResult> PostVendor(Vendor vendor)
        {
           
            _context.vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return Ok();
            //return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }
        //asmaa
        [HttpGet("Getvendor/{id}")]
        public ActionResult Getvendor(string id)
        {
            var x = _context.vendors.Where(a => a.vendor_id == id).Select(e => new
            {
                vendorname = e.ApplicationUser.UserName,
                instgram = e.Instgram,
                facebook = e.FacebookLink,
                twitter = e.Twitterr,
                image = e.PersonalImage,
                cat = e.category.cat_Name,
            }).FirstOrDefault();

            return Ok(x);
        }
    }






}
