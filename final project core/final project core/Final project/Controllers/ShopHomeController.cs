using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_project.Models;
using Final_project.Models.our_tables;
using Final_project.Models.viewmodels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopHomeController : ControllerBase
    {
        private readonly ProjectDbcontext _context;

        private static IWebHostEnvironment environment;
        private readonly IHttpContextAccessor contextAccessor;

        public ShopHomeController(ProjectDbcontext context, IWebHostEnvironment _environment, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            environment = _environment;
            this.contextAccessor = contextAccessor;
        }
        [HttpGet]
        [Route("GetAllProductType")]
        public async Task<ActionResult> GetAllProductType()
        {
            List<productType> productType = await _context.ProductTypes.ToListAsync();
            if (productType != null)
            {
                return Ok(productType);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<ActionResult> GetAllProduct()
        {
            List<product> products = await _context.products.ToListAsync();

           // List<product> products = await _context.products.Where(a => a.Exp_date.Month - DateTime.Now.Month > 1).ToListAsync();
            if (products != null)
            {
                for (int i = 0; i < products.Count(); i++)
                {
                    products[i].product_image = Process(products[i].product_image);
                }
                return Ok(products);
            }
            else {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetProudctById/{id}")]
        public async Task<ActionResult> GetProudctById(int id)
        {
            product product = await _context.products.FindAsync(id);
            if(product != null)
            {
                product.product_image = Process(product.product_image);
                return Ok(product);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("PostOrder")]
        public async Task<ActionResult> PostOrder(OrderViewModel orderViewModel)
        {
            Order order = new Order();
            order.CustomerID = orderViewModel.Id;
            order.OrderDateTime= DateTime.Now;
            order.OrderDetails = new List<OrderDetails>();
            foreach(var item in orderViewModel.OrderDetails)
            {
                order.OrderDetails.Add(new OrderDetails()
                {
                    ProductID = item.ProductID,
                    Qtu = item.Qtu,
                    UnitPrice = item.Price
                });
            }
            int tempamount = 0;
            foreach(var item in orderViewModel.OrderDetails)
            {
                tempamount += (item.Price * item.Qtu);
            }
          await  _context.Orders.AddAsync(order);
           await _context.SaveChangesAsync();
            return Ok(order);
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
}
