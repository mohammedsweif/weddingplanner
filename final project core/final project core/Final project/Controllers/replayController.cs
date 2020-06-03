using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class replayController : ControllerBase
    {
        private readonly ProjectDbcontext _context;
        public replayController(ProjectDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Getureplay()
        {
            var x = _context.review_Replays.Select(e => new
            {
                ID = e.ID,
                Review_Id = e.Review_Id,
                PostDate = e.PostDate,
                Comment = e.Comment,
                User_Id = e.User_Id,
                Vendor_Id = e.Vendor_Id
            }).ToList();
            return Ok(x);
        }

        //to add replay
        [HttpPost("Add")]
        public ActionResult<Review_replays> Postreplay([FromBody]Review_replays n)
        {
            _context.review_Replays.Add(n);
            _context.SaveChanges();
            return Ok(n);
        }


    }
}