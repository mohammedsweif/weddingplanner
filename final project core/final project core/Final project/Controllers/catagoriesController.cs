using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_project.Models;
using Final_project.Models.OurIdentity;

namespace Final_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class catagoriesController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public catagoriesController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: api/catagories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<catagory>>> Getcatagories()
        {
            return await _context.catagories.ToListAsync();
        }

        // GET: api/catagories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<catagory>> Getcatagory(int id)
        {
            var catagory = await _context.catagories.FindAsync(id);

            if (catagory == null)
            {
                return NotFound();
            }

            return catagory;
        }

        // PUT: api/catagories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcatagory(int id, catagory catagory)
        {
            if (id != catagory.cat_Id)
            {
                return BadRequest();
            }

            _context.Entry(catagory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!catagoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/catagories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<catagory>> Postcatagory(catagory catagory)
        {
            _context.catagories.Add(catagory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcatagory", new { id = catagory.cat_Id }, catagory);
        }

        // DELETE: api/catagories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<catagory>> Deletecatagory(int id)
        {
            var catagory = await _context.catagories.FindAsync(id);
            if (catagory == null)
            {
                return NotFound();
            }

            _context.catagories.Remove(catagory);
            await _context.SaveChangesAsync();

            return catagory;
        }

        private bool catagoryExists(int id)
        {
            return _context.catagories.Any(e => e.cat_Id == id);
        }
    }
}
