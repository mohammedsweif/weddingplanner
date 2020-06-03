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
    [Route("[controller]")]
    [ApiController]
    public class counteventController : ControllerBase
    {
        private readonly ProjectDbcontext _context;
        public counteventController(ProjectDbcontext context)
        {
            _context = context;
        }

        public IActionResult Getucountevent()
        {
            var x = (from b in _context.events
                     select new
                     {   Id=b.id,
                         Name = b.Event_name,
                         packCount = _context.packages.Count(a => a.Event_id == b.id)
                     }).ToList();
            var count = x.OrderByDescending(s => s.packCount);
            return Ok(count);
        }
        [HttpDelete("{id}")]
        [Route("Deletevent")]
        public IActionResult Deletevent(int id)
        {
            var s = _context.events.Find(id);

            _context.events.Remove(s);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("{c}")]
        [Route("Postevent")]
        public ActionResult<Event> Postevent([FromBody]Event c)
        {
            _context.events.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }


    }
}