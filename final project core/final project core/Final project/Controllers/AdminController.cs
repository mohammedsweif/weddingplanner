using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.OurIdentity;
using Final_project.Models.viewmodels;
using Final_project.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
   
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        ProjectDbcontext db;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public AdminController(ProjectDbcontext _db,UserManager<ApplicationUser> _userManager,RoleManager<IdentityRole> _roleManager)
        {
            db = _db;
            userManager = _userManager;
            roleManager = _roleManager;
        }
        [HttpGet]
        [Route("allusers")]
        public async Task<IActionResult> alluserAsync()
        {
            List<AdminUsersViewModel> lis = new List<AdminUsersViewModel>();
            List<ApplicationUser> xxxx = userManager.Users.ToList();
            List<ApplicationUser> user = db.Users.ToList();
            xxxx = (List<ApplicationUser>)await userManager.GetUsersInRoleAsync("user");
            lis = xxxx.Select(x => new AdminUsersViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                Books = db.booking.Where(e => e.UserId == x.Id).ToList().Count()

            }).ToList();
            /* foreach (var x in user)
             {
                 AdminUsersViewModel adminUsersViewModel = new AdminUsersViewModel();
                 if (await userManager.IsInRoleAsync(x, "user"))
                 {
                     adminUsersViewModel.Id = x.Id;
                     adminUsersViewModel.UserName = x.UserName;
                     adminUsersViewModel.Email = x.Email;
                     int books=db.booking.Where(e => e.UserId == x.Id).ToList().Count();
                     adminUsersViewModel.Books = books;
                     lis.Add(adminUsersViewModel);
                 }
             }*/
            return Ok(lis);
        }


        //----------------------------------------------------------

        [HttpPost]
        [Route("sendmessage")]
        public void postme(Messagess m)
        {
            string Subject = "Wedding Plane ";
            string Body = m.messagee;
            foreach (string x in m.ids)
            { SendEmail.Excute(x, Subject, Body); }

        }




        [HttpGet("getallUsers")]
        public ActionResult getallUsers()
        {
            var User = db.Users.Select(user => new { id = user.Id, name = user.UserName });
            return Ok(User);
        }


        //-------------------------------------------------------------------------------------
        [HttpGet("getTopUser")]
        public ActionResult getTopUser()
        {
            List<TopUser> topUsers = new List<TopUser>();
            var user = userManager.Users.ToList();
            foreach (var i in db.booking.GroupBy(e => e.UserId).Select(group => new
            {   
                count = group.Count(),
                id = group.Key

            }).OrderByDescending(a => a.count)){
                TopUser use = new TopUser { count = i.count, id = i.id };
                ApplicationUser user1= user.FirstOrDefault(e => e.Id == use.id);
                use.username = user1.UserName;
                topUsers.Add(use) ;
              
            }

            return Ok(topUsers);
        }
      

        //--------------------------------------------------------------------------------

        [HttpGet("getTopCategories")]
        public ActionResult getTopCategories()
        {
            List<TopCategory> topCategories = new List<TopCategory>();
            var catlist = db.catagories.ToList();
            foreach (var i in db.booking.GroupBy(e => e.CategoryId).Select(group => new
            {

                count = group.Count(),
                id = group.Key
            }).OrderByDescending(a => a.count))
            {
                TopCategory tcat= new TopCategory { count = i.count, id = i.id };
                catagory cat = catlist.FirstOrDefault(e => e.cat_Id == tcat.id);
                tcat.catname = cat.cat_Name;
                topCategories.Add(tcat);
            }

            return Ok(topCategories);
        }

        [HttpGet("getTopVendors")]
        public ActionResult getTopVendors()
        {
            List<TopVendor> topVendors = new List<TopVendor>();
            var user = userManager.Users.ToList();
            foreach (var i in db.booking.ToList().GroupBy(e => new { e.VendorId }).Select(group => new
            {

                count = group.Count(),
                id = group.Key.VendorId,
                // category_id=group.Key.CategoryId

            }).OrderByDescending(a => a.count))
            {
                TopVendor use = new TopVendor { count = i.count, id = i.id };
                ApplicationUser user1 = user.FirstOrDefault(e => e.Id == use.id);
                use.username = user1.UserName;
                 
                topVendors.Add(use);
            }
            //var topdist= topVendors.GroupBy(i => i.id).Select(i => i.FirstOrDefault()).ToList();
            return Ok(topVendors);
        }


        [HttpGet]
        [Route("bookdetails")]
        public async Task<ActionResult> bookdetails()
        {
            var booklist = await db.booking.Include(a => a.vendor).Include(a => a.category).Include(a => a.user).Select(a => new {
                bookDate = a.BookDate.ToString("yyyy-MM-dd"),
                category = a.category.cat_Name,
                cost = a.Cost,
                cat_Id = a.CategoryId,
                realdate = a.RealDate.ToString("yyyy-MM-dd"),
                VendorName = a.vendor.UserName,
                UserName = a.user.UserName,
                status = a.Status,
            }).ToListAsync();
            return Ok(booklist);
        }
       

        [HttpGet]
        [Route("getProducts")]
        public ActionResult getProducts()

        {
            var list = db.products.ToList();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("getTypes")]
        public ActionResult getTypes()
        {
            var list = db.ProductTypes.ToList();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("addType")]
        public ActionResult addType([FromBody]productType productType)
        {
            if (productType != null)
            {
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return Ok(productType);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("getOneProduct/{id}")]
        public ActionResult getOneProduct(int id)

        {
            var product = db.products.FirstOrDefault(a => a.product_id == id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("deleteProduct/{id}")]
        public ActionResult deleteProduct(int id)
        {
            var product = db.products.FirstOrDefault(a => a.product_id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                db.products.Remove(product);
                db.SaveChanges();
                return Ok(product);
            }
        }



        [HttpPost]
        [Route("editProduct")]
        public ActionResult editProduct([FromBody]product product)
        {
            var toEdit = db.products.FirstOrDefault(a => a.product_id == product.product_id);

            if (toEdit != null)
            {
                toEdit.product_image = product.product_image;
                toEdit.price = product.price;
                toEdit.old_price = product.old_price;
                toEdit.quantity = product.quantity;
                toEdit.type_id = product.type_id;
                db.SaveChanges();
                return Ok(toEdit);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("addProduct")]
        public ActionResult addProduct([FromBody]product product)
        {
            if (product != null)
            {
                db.products.Add(product);
                db.SaveChanges();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }

        }
      
    }
}