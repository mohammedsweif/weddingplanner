using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Final_project.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
   
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IHttpContextAccessor contextAccessor;

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpContextAccessor contextAccessor;

        ProjectDbcontext db;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ProjectDbcontext _db, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            db = _db;
            this.contextAccessor = contextAccessor;
 
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult getall()
        {
            List<Vendor_CategorViewModel> x = db.vendors.Select(e => new Vendor_CategorViewModel
            {
                id = e.vendor_id,
                image =   e.ApplicationUser.ImageUrl,
                name = e.ApplicationUser.UserName,
                catagor = e.category.cat_Name,
                cat_id = e.catt_id,
                rate = 0
            }).ToList();
 
            for (int i = 0; i < x.Count; i++)
            {
                x[i].image = Process(x[i].image);

            }

 
            foreach (var y in x)
            {
                int numer = 0;
                int sum = 0;
                foreach (var r in db.ratings)
                {
                    if (r.Vendor_Id == y.id && r.Category_Id == y.cat_id)
                    {
                        numer++;
                        sum += r.Rate;
                    }
                }
                if (sum != 0 && numer != 0)
                    y.rate = sum / numer;
            }
            return Ok(x);
        }
        [HttpGet("getallcatagory")]
        public ActionResult<List<catagory>> getallcatagory()
        {
            return Ok(db.catagories.ToList());
        }
        private string Process(string Image)
        {
            //get domain name;
            var request = this.contextAccessor.HttpContext.Request;
            //make path for Image   
            string path = $"{request.Scheme}://{request.Host.Value}/images/{Image}";
            return path;
        }
    }
    public class Vendor_CategorViewModel
    {

        public string id { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string catagor { get; set; }
        public int cat_id { get; set; }
        public int rate { get; set; }

    }
}
