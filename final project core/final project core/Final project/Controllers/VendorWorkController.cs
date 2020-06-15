using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.OurIdentity;
using Final_project.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendorWorkController : ControllerBase
    {
        VendorWorksRepsitory _WorksRepo;
        public VendorWorkController(VendorWorksRepsitory worksRepsitory)
        {
            _WorksRepo = worksRepsitory;
        }

        [HttpGet("Index")]
        public ActionResult Index()
        {
            var Works = _WorksRepo.GetAll();
            if (Works != null)
            {
                return Ok(Works);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }

        }

        [HttpGet("GetbyId/{id:int}")]
        public ActionResult<VendorWorks> GetbyId(int id)
        {
            var Work = _WorksRepo.GetOnebyId(id);
            if (Work == null)
            {
                return NotFound(new { msg = "not found" });
            }
            else
            {
                return Ok(Work);
            }

        }


        [HttpPost("Add")]
        public ActionResult AddWork([FromBody]VendorWorks work)
        {
            bool result = _WorksRepo.Add(work);

            if (result)
            {
                return Ok(new { msg = "Added" });
            }

            else
            {
                return BadRequest(new { msg = "not added" });
            }

        }

        [HttpPost("addInVendor")]
        public ActionResult addInVendor([FromBody]VenBudget vendor)
        {
            bool result = _WorksRepo.addInVendor(vendor);

            if (result)
            {
                return Ok(new { msg = "Added" });
            }

            else
            {
                return BadRequest(new { msg = "not added" });
            }

        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public ActionResult DeleteWork(int id)
        {
            bool result = _WorksRepo.Delete(id);

            if (result)
            {
                return Ok(new {msg="deleted" });
            }

            else
            {
                return BadRequest(new { msg = "not deleted" });
            }

        }

        [HttpPost("Edit")]

        public ActionResult EditWork([FromBody]VendorWorks work)
        {
            bool result = _WorksRepo.Edit(work);

            if (result)
            {
                return Ok(work);
            }

            else
            {
                return BadRequest(new { msg = "not modified" });
            }

        }


        [HttpGet("GetVenCategories/{id}")]
        public ActionResult GetVenCategories(string id)
        {
            var cats = _WorksRepo.GetVendorCateg(id);
            if (cats != null)
            {
                return Ok(cats);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }
        }

        [HttpGet("GetNoBudgetCateg/{id}")]
        public ActionResult GetNoBudgetCateg(string id)
        {
            var cats = _WorksRepo.GetNoBudgetCateg(id);
            if (cats != null)
            {
                return Ok(cats);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }
        }

        [HttpGet("getVenData/{id}")]
        public ActionResult getVenData(string id)
        {
            var Vendor = _WorksRepo.getVenData(id);
            if (Vendor != null)
            {
                return Ok(Vendor);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }
        }



        [HttpGet("AllCategories")]
        public ActionResult GetAllCategories()
        {
            var categories = _WorksRepo.GetAllCategories();
            if (categories != null)
            {
                return Ok(categories);
            }

            else
            {
                return BadRequest(new { msg = "not found" });
            }

        }

        [HttpGet("Getbudget/{id}/{id1:int}")]
        public ActionResult<VenBudget> Getbudget(string id,int id1)
        {
            var bd = _WorksRepo.Getbudget(id,id1);
            if (bd == null)
            {
                return NotFound(new { msg = "not found" });
            }
            else
            {
                return Ok(bd);
            }

        }

        [HttpPost("EditBudgetData")]

        public ActionResult EditBudgetData([FromBody]VenBudget bd)
        {
            bool result = _WorksRepo.EditBudgetData(bd);

            if (result)
            {
                return Ok(bd);
            }

            else
            {
                return BadRequest(new { msg = "not modified" });
            }

        }

        [HttpGet("GetTotalBudget/{id}/{id1:int}")]
        public ActionResult GetTotalBudget(string id, int id1)
        {
            int t = _WorksRepo.GetTotalBudget(id, id1);
            return Ok(t);
        }

        [HttpGet("GetTotalBudgetPaid/{id}/{id1:int}")]
        public ActionResult GetTotalBudgetPaid(string id, int id1)
        {
            int t = _WorksRepo.GetTotalBudgetPaid(id, id1);
            return Ok(t);
        }

        [HttpGet("GetTotalBudgetPending/{id}/{id1:int}")]
        public ActionResult GetTotalBudgetPending(string id, int id1)
        {
            int t = _WorksRepo.GetTotalBudgetPending(id, id1);
            return Ok(t);
        }

    }
}