using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly ProjectDbcontext _context;
        public RatingController(ProjectDbcontext context)
        {
            _context = context;
        }
        [HttpGet("Getrate/{id}")]
        public IActionResult Getrate(string id)
        {
            var x = _context.ratings.Where(a => a.Vendor_Id == id).Select(e => new
            {
                rate = e.Rate
            }).ToList();
            var avg = x.Average(e => e.rate);
            return Ok(avg);
        }
    }
}

