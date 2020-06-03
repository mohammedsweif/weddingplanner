using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserProductsController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public UserProductsController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: api/UserProducts
        [HttpGet]
        public ActionResult<IEnumerable<UserProduct>> GetuserProducts()
        {
            var getall = _context.userProducts.Select(
                a => new
                {
                    a.piece_id,
                    UserName = a.ApplicationUser.UserName,
                    a.userseller_id,
                    a.status,
                    a.piece_Cost,
                    a.Image,
                    a.piece_description,
                    a.publish_date,
                    a.available_date


                }).ToList();
            return Ok(getall);
        }

        // GET: api/UserProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserProduct>> GetUserProduct(int id)
        {
            var userProduct = await _context.userProducts.FindAsync(id);

            if (userProduct == null)
            {
                return NotFound();
            }

            return userProduct;
        }

        // PUT: api/UserProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProduct(int id, UserProduct userProduct)
        {
            if (id != userProduct.piece_id)
            {
                return BadRequest();
            }

            _context.Entry(userProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProductExists(id))
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

        // POST: api/UserProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("PostUserProduct")]
        public ActionResult<UserProduct> PostUserProduct(UserProduct userProduct)
        {
            _context.userProducts.Add(userProduct);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/UserProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserProduct>> DeleteUserProduct(int id)
        {
            var userProduct = await _context.userProducts.FindAsync(id);
            if (userProduct == null)
            {
                return NotFound();
            }

            _context.userProducts.Remove(userProduct);
            await _context.SaveChangesAsync();

            return userProduct;
        }

        private bool UserProductExists(int id)
        {
            return _context.userProducts.Any(e => e.piece_id == id);
        }
    }
}