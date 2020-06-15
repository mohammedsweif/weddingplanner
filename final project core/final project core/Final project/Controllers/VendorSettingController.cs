using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.OurIdentity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendorSettingController : ControllerBase
    {

        private readonly ProjectDbcontext _context;

        private static IWebHostEnvironment environment;
        private readonly IHttpContextAccessor contextAccessor;
        public VendorSettingController(ProjectDbcontext context, IWebHostEnvironment _environment, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            environment = _environment;
  
            this.contextAccessor = contextAccessor;
        }
        [HttpPost]
        [Route("UploadImage")]
        public async Task<ActionResult> UploadImage(ImageVM imageVM)
        {
            var user = await _context.Users.FindAsync(imageVM.id);
            if (user != null)
            {
                string image = ConvertImage(imageVM.Imageurl);
                user.ImageUrl = image;
                await _context.SaveChangesAsync();
                return Ok(new { Imagesrc = user.ImageUrl });
            }
            else
            {
                return NotFound();
            }

        }
        public static string ConvertImage(string ImageUrl)
        {

            string ImageProcess = ImageUrl.Split("base64,")[1];
            byte[] by = Convert.FromBase64String(ImageProcess);

            ImageConverter imageConverter = new ImageConverter();
            Image image = (Image)imageConverter.ConvertFrom(by);
            string extension = ".png";
            string Name = Guid.NewGuid().ToString() + extension;
            string fullpath = Path.Combine(environment.WebRootPath, "images", Name);
            image.Save(fullpath);
            return Name;
        }
    }
}
