using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class packageController : ControllerBase
    {
        ProjectDbcontext _context;
        public packageController(ProjectDbcontext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult Getpackages()
        {
            List<Package> list = _context.packages.ToList();
            if (list != null)
            {
                return Ok(list);
            }

            else
            {
                return NotFound(new { msg = "not found" });
            }
        }

        [HttpPost("PostPackage")]
        public ActionResult<Package> PostPackage([FromBody]Package package)
        {
            if (package != null)
            {
                package.status = true;
                _context.packages.Add(package);
                _context.SaveChanges();
                return Ok(package);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }

        }


        [HttpDelete("{id}")]
        public ActionResult<Package> DeletePackage(int id)
        {
            var package = _context.packages.FirstOrDefault(a => a.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            if (package.status == false)
            {
                package.status = true;
            }
            else if (package.status == true)
            {
                package.status = false;
            }
            _context.SaveChanges();

            return package;
        }

        [HttpPut("{id}")]
        public ActionResult PutPackage(Package newPackage)
        {
            Package pack = _context.packages.FirstOrDefault(a => a.PackageId == newPackage.PackageId);

            if (pack != null)
            {
                pack.status = newPackage.status;
                pack.feature_name = newPackage.feature_name;
                pack.description = newPackage.description;
                pack.season_id = newPackage.season_id;
                pack.PackageCost = newPackage.PackageCost;
                pack.Event_id = newPackage.Event_id;
                pack.catagory_id = newPackage.catagory_id;
                pack.VendorId = newPackage.VendorId;
                _context.SaveChanges();
                return Ok(newPackage);
            }
            else
            {
                return BadRequest(new { msg = "not found" });
            }

        }

        [HttpGet("GetVenEvents/{id}")]
        public ActionResult getEvent(string id)
        {
         List<Package> list= _context.packages.Where(p => p.VendorId==id).ToList();
            List<Event> evList = new List<Event>();
            foreach(var i in list)
            {
                if (!evList.Exists(a => a.id== i.Event_id))
                {
                    evList.Add(_context.events.FirstOrDefault(a => a.id == i.Event_id));
                }
                
            }
            return Ok(evList);
        }


        [HttpGet("GetVenSeasons/{id}")]
        public ActionResult getSeason(string id)
        {
            List<Package> list = _context.packages.Where(p => p.VendorId == id).ToList();
            List<season> sList = new List<season>();
            foreach (var i in list)
            {
                if (!sList.Exists(a => a.season_id == i.season_id))
                {
                    sList.Add(_context.seasons.FirstOrDefault(a => a.season_id == i.season_id));
                }
                    
            }
            return Ok(sList);
        }


        //[HttpGet("GetVenFeatures/{id}")]
        //public ActionResult getFeatures(string id)
        //{
        //    List<Package> list = _context.packages.Where(p => p.VendorId == id).ToList();
        //    List<packagefeatures> sList = new List<packagefeatures>();
        //    foreach (var i in list)
        //    {
        //        if (!sList.Exists(a => a.feature_id == i.Feature_id))
        //        {
        //            sList.Add(_context.PackageFeatures.FirstOrDefault(a => a.feature_id == i.Feature_id));
        //        }
                    
        //    }
        //    return Ok(sList);
        //}


        [HttpGet("GetbyId/{id:int}")]
        public ActionResult<Package> GetbyId(int id)
        {
            Package p = _context.packages.FirstOrDefault(a => a.PackageId == id);
            return p;

        }
    }
}