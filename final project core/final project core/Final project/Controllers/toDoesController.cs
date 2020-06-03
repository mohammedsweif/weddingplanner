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
    public class toDoesController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public toDoesController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: api/toDoes
        [HttpGet]
        public ActionResult<IEnumerable<toDo>> GettoDo()
        {
            return _context.toDo.ToList();
        }

        // GET: api/toDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<toDo>> GettoDo(int id)
        {
            var toDo = await _context.toDo.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return toDo;
        }

        // PUT: api/toDoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Route("PuttoDo")]
        public IActionResult PuttoDo(toDo newToDo)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //_context.Entry(toDo).State = EntityState.Modified;



            toDo oldToDo = _context.toDo.FirstOrDefault(a => a.id == newToDo.id);

            if (oldToDo != null)
            {
                oldToDo.Vendor_Id = newToDo.Vendor_Id;
                oldToDo.Description = newToDo.Description;

                _context.SaveChanges();
                return Ok(newToDo);
            }

            else
            {
                return BadRequest();
            }


        }

        // POST: api/toDoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("PosttoDo")]
        public ActionResult<toDo> PosttoDo(toDo toDo)
        {
            _context.toDo.Add(toDo);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/toDoes/5
        [HttpDelete("{id}")]
        public ActionResult<toDo> DeletetoDo(int id)
        {
            var toDo = _context.toDo.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.toDo.Remove(toDo);
            _context.SaveChanges();

            return toDo;
        }

        private bool toDoExists(int id)
        {
            return _context.toDo.Any(e => e.id == id);
        }
    }
}