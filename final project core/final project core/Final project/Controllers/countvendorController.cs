using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class countvendorController : ControllerBase
    {

        private readonly ProjectDbcontext _context;
        public countvendorController(ProjectDbcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Getureviews()
        {
            var x = (from b in _context.catagories
                     select new
                     {
                         Id=b.cat_Id,
                         Name = b.cat_Name,
                         vendorCount = _context.vendors.Count(a => a.catt_id == b.cat_Id)
                     }).ToList();
            var count = x.OrderByDescending(s =>s.vendorCount);
            return Ok(count);
        }

        [HttpDelete("{id}")]
        [Route("Deletecatagory")]
        public IActionResult Deletecatagory(int id)
        {
            var catagory = _context.catagories.Find(id);
          
            _context.catagories.Remove(catagory);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost ("{c}")]
        [Route("Postcat")]
        public ActionResult<catagory> Postcat([FromBody]catagory c)
        {
            _context.catagories.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }


    }
}