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
    public class VendorBusiesController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        public VendorBusiesController(ProjectDbcontext context)
        {
            _context = context;
        }

        // GET: VendorBusies
        [HttpGet]
        public ActionResult<IEnumerable<VendorBusy>> GetvendorBusies()
        {
            return _context.vendorBusies.ToList();
        }

        // GET: api/VendorBusies/5
        [HttpGet("{id}")]
        ///[Route("GetVendorBusy")]
        public ActionResult<VendorBusy> GetVendorBusy(int id)
        {
            var vendorBusy = _context.vendorBusies.Find(id);

            if (vendorBusy == null)
            {
                return NotFound();
            }

            return vendorBusy;
        }

        // PUT: api/VendorBusies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        [Route("PutVendorBusy")]
        public IActionResult PutVendorBusy([FromBody] VendorBusy vendorBusy)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                VendorBusy vendor = _context.vendorBusies.Where(a => a.Id == vendorBusy.Id).FirstOrDefault();
                /// vendor.Id = vendorBusy.Id;
                // vendor.vendor_id = vendorBusy.vendor_id;
                //vendor.BookingId = vendorBusy.BookingId;
                vendor.BusyDay = vendorBusy.BusyDay.Date;
                // vendor.Reason = vendorBusy.Reason;
                vendor.Status = vendorBusy.Status;
                //_context.Entry(vendorBusy).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(vendorBusy);
            }
            catch
            {
                return BadRequest();
            }


        }

        // POST: api/VendorBusies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("PostVendorBusy")]
        public ActionResult PostVendorBusy([FromBody]VendorBusy vendorBusy)
        {
            //vendorBusy.id = 0;
            ///vendorBusy.vendor_id = "11A";
           // _context.Entry(vendorBusy).State = EntityState.Added;
            _context.vendorBusies.Add(vendorBusy);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/VendorBusies/5
        [HttpDelete("{id}")]

        public ActionResult<VendorBusy> DeleteVendorBusy(int id)
        {
            var vendorBusy = _context.vendorBusies.Find(id);
            if (vendorBusy == null)
            {
                return NotFound();
            }

            _context.vendorBusies.Remove(vendorBusy);
            _context.SaveChanges();

            return vendorBusy;
        }

        private bool VendorBusyExists(int id)
        {
            return _context.vendorBusies.Any(e => e.Id == id);
        }
    }
}