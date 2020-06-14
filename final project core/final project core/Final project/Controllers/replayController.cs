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
                comment = e.Comment,
                User_Id = e.User_Id,
                Vendor_Id = e.Vendor_Id,
                liked=e.liked
            }).ToList();
            return Ok(x);
        }

        [HttpPut("toggleReply")]
        public ActionResult toggleReply([FromBody] Review_replays replay)
        {
            var r = _context.review_Replays.FirstOrDefault(a => a.ID == replay.ID);
            r.liked = !r.liked;
            _context.SaveChanges();
            return Ok(r);
        }

        [HttpPut("toggleReview")]
        public ActionResult toggleReview([FromBody] Review_replays replay)
        {
            var r = _context.reviews.FirstOrDefault(a => a.ID == replay.ID);
            r.liked = !r.liked;
            _context.SaveChanges();
            return Ok(r);
        }


    }
}