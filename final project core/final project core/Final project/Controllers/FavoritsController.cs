using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class FavoritsController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public FavoritsController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: api/Favorits
        [HttpGet]
        public ActionResult<IEnumerable<Favorit>> Getfavorits()
        {

            var y = _context.favorits.Select(a => new
            {
                a.Id,
                a.vendor_id,
                a.date,
                vendorName = a.vendor.UserName,
                a.image,
                a.cat_id,
                catName = a.catagory.cat_Name,
                a.about

            });
            return Ok(y);
        }

        // GET: api/Favorits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorit>> GetFavorit(int id)
        {
            var favorit = await _context.favorits.FindAsync(id);

            if (favorit == null)
            {
                return NotFound();
            }

            return favorit;
        }

        // PUT: api/Favorits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorit(int id, Favorit favorit)
        {
            if (id != favorit.Id)
            {
                return BadRequest();
            }

            _context.Entry(favorit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritExists(id))
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

        // POST: api/Favorits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Favorit>> PostFavorit(Favorit favorit)
        {
            _context.favorits.Add(favorit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorit", new { id = favorit.Id }, favorit);
        }

        // DELETE: api/Favorits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Favorit>> DeleteFavorit(int id)
        {
            var favorit = await _context.favorits.FindAsync(id);
            if (favorit == null)
            {
                return NotFound();
            }

            _context.favorits.Remove(favorit);
            await _context.SaveChangesAsync();

            return favorit;
        }

        private bool FavoritExists(int id)
        {
            return _context.favorits.Any(e => e.Id == id);
        }
    }
}