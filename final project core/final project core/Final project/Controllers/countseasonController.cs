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
    public class countseasonController : ControllerBase
    {
        private readonly ProjectDbcontext _context;
        public countseasonController(ProjectDbcontext context)
        {
            _context = context;
        }

        public IActionResult Getcountseason()
        {
            var x = (from b in _context.seasons
                     select new
                     {
                         Id=b.season_id,
                         Name = b.season_name,
                         Startdate=b.start_time,
                         period=b.period,
                         seasonCount = _context.packages.Count(a => a.season_id == b.season_id)
                     }).ToList();
            var count = x.OrderByDescending(s => s.seasonCount);
            return Ok(count);
        }

        [HttpDelete("{id}")]
        [Route("Deleteseason")]
        public IActionResult Deleteseason(int id)
        {
            var s = _context.seasons.Find(id);

            _context.seasons.Remove(s);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("{c}")]
        [Route("Postseason")]
        public ActionResult<season> Postseason([FromBody]season c)
        {
            _context.seasons.Add(c);
            _context.SaveChanges();
            return Ok(c);
        }

    }
}