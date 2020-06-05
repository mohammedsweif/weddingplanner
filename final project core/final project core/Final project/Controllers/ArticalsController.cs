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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticalsController : ControllerBase
    {
        private readonly ProjectDbcontext _projectDbcontext;
        private readonly IHttpContextAccessor _contextAccessor;
        private static IWebHostEnvironment _environment;

        public ArticalsController(ProjectDbcontext projectDbcontext, IHttpContextAccessor contextAccessor, IWebHostEnvironment environment)
        {
            _projectDbcontext = projectDbcontext;
            _contextAccessor = contextAccessor;
            _environment = environment;
            
        }
        [HttpGet]
        [Route("GetAllArticals")]
        public async Task<ActionResult> GetAllArticals()
        {
            IList<Article> articles = await _projectDbcontext.articles.Include(a=>a.catagory).Include(a=>a.applicationUser).ToListAsync();
            foreach(Article article in articles)
            {
                article.ImageUrl = Proccess(article.ImageUrl);
            }
            return Ok(articles);
        }
        [HttpGet]
        [Route("GetArticalDetails/{id}")]
        public async Task<ActionResult> GetArticalsDetails(int id)
        {
            Article article = await _projectDbcontext.articles.FindAsync(id);
            if(article != null)
            {
                article.ImageUrl = Proccess(article.ImageUrl);
                return Ok(article);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpDelete]
        [Route("DeleteArtical/{id}")]
        public async Task<ActionResult> DeleteAtrical(int id)
        {
            Article article = await _projectDbcontext.articles.FindAsync(id);
            if (article != null)
            {
                 _projectDbcontext.articles.Remove(article);
                  await  _projectDbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("AddArtical")]
        public async Task<ActionResult> AddArtical(Article artical)
        {
            if (ModelState.IsValid) 
            {
                string image= ConvertImage(artical.ImageUrl);
                artical.ImageUrl = image;
                await _projectDbcontext.articles.AddAsync(artical);
                await _projectDbcontext.SaveChangesAsync();
                artical.ImageUrl = Proccess(artical.ImageUrl);
                return Ok(artical);
            }
            else
            {
                return NoContent();
            }
          
        }
        [HttpPost]
        [Route("EditArticals")]
        public async Task<ActionResult> EditArtical(Article artical)
        {
            if (ModelState.IsValid)
            {
                _projectDbcontext.Entry(artical).State = EntityState.Modified;
                await _projectDbcontext.SaveChangesAsync();
               
                return Ok();
            }
            else
            {
                return NotFound();
            }   
            
        }
        public static string ConvertImage(string Image)
        {
            string ImageProccess = Image.Split("base64,")[1];
            byte[] by = Convert.FromBase64String(ImageProccess);
            ImageConverter imageConverter = new ImageConverter();
            Image image=(Image)imageConverter.ConvertFrom(by);
            string Extension = ".png";
            string Name = Guid.NewGuid()+ Extension;
            string path = Path.Combine(_environment.WebRootPath,"images",Name);
            image.Save(path);
            return Name;
        }
        public string Proccess(string Image)
        {
            HttpRequest request = _contextAccessor.HttpContext.Request;
            string path = $"{request.Scheme}://{request.Host.Value}/images/{Image}";
            return path;
        }
    }
}
