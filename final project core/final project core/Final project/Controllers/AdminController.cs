using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.viewmodels;
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

        [HttpGet]
        [Route("allusers")]
        public async Task<IActionResult> alluserAsync()
        {
            List<AdminUsersViewModel> lis = new List<AdminUsersViewModel>();
            List<ApplicationUser> xxxx = userManager.Users.ToList();
            List<ApplicationUser> user = db.Users.ToList();

            foreach (var x in user)
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
            }
            return Ok(lis);
        }

        
	//----------------------------------------------------------

        [HttpPost]
        [Route("sendmessage")]
        public void postme(List<string> str)
        {

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
            foreach (var i in db.booking.GroupBy(e => e.UserId).Select(group => new
            {

                count = group.Count(),
                id = group.Key
            }).OrderByDescending(a => a.count))
            {
                topUsers.Add(new TopUser { count = i.count, id = i.id });
            }

            return Ok(topUsers);
        }

        //--------------------------------------------------------------------------------

        [HttpGet("getTopCategories")]
        public ActionResult getTopCategories()
        {
            List<TopCategory> topCategories = new List<TopCategory>();
            foreach (var i in db.booking.GroupBy(e => e.CategoryId).Select(group => new
            {

                count = group.Count(),
                id = group.Key
            }).OrderByDescending(a => a.count))
            {
                topCategories.Add(new TopCategory { count = i.count, id = i.id });
            }

            return Ok(topCategories);
        }

        [HttpGet("getTopVendors")]
        public ActionResult getTopVendors()
        {
            List<TopVendor> topVendors = new List<TopVendor>();
            foreach (var i in db.booking.ToList().GroupBy(e => new { e.VendorId }).Select(group => new
            {

                count = group.Count(),
                id = group.Key.VendorId,
                // category_id=group.Key.CategoryId

            }).OrderByDescending(a => a.count))
            {
                topVendors.Add(new TopVendor { count = i.count, id = i.id });
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
    }
}