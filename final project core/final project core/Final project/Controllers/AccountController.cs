using Final_project.Models;
using Final_project.Models.OurIdentity;
using Final_project.service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Final_project.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ProjectDbcontext db;
        public AccountController(UserManager<ApplicationUser> _userManager,
                                 RoleManager<IdentityRole> _roleManager,
                                 SignInManager<ApplicationUser> _signInManager,
                                 ProjectDbcontext _db)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            db = _db;
        }

        [HttpPost]
        [Route("Register/{type}")]
        // http://localhost:50414/account/Register
        /*
             *  
            Content-Type: application/json; charset=utf-8

          {
            "UserName":"mohadffrefrfmmed",
            "Email":"a@a.a",
            "Password":"123+Aa",
            "ConfirmPassword":"123+Aa"
} 
             */
        public async Task<IActionResult> Register(RegisterViewModel model,[FromRoute]int type)
        {
            if (ModelState.IsValid)
            {
                 if (EmailExsist(model.Email))
                {
                    return BadRequest("Email is exist");
                } 


                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if(type == 2) { 
                    await userManager.AddToRoleAsync(user, "user");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "vendor");
                    }
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmation = Url.Action("registerationconfirm", "Account", new
                    {
                        Id = user.Id,
                        Token = HttpUtility.UrlEncode(token)
                    }, Request.Scheme);
                    string Subject = "Wedding Planner Confirmation";
                    string Body = "Hello " + user.UserName +" "+",this is a confirmation email from RAWNAK ,Please press here to proceed" +" " +"<a href=" + confirmation + ">Confirm</a>";
                    if (SendEmail.Excute(user.Email, Subject, Body))
                    {
                        return Ok();

                    }
                }
            }
            return NotFound("check your data again");
        }
        /***************************************************************************/
        public bool EmailExsist(string Email)
        {
            if(db.Users.FirstOrDefault(x => x.Email == Email) != null)
                return true;
            return false;
        }
        /**************************************************************************/
        [HttpGet]
        [Route("registerationconfirm")]
        public async Task<IActionResult> registerationconfirm(string Id, string Token)
        {
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Token))
            {
                return NotFound();
            }
            var user = await userManager.FindByIdAsync(Id);
            if (user == null)
                return NotFound();
            var result = await userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(Token));
            if (result.Succeeded)
            {
                return Ok("has been confirmed");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }




        /*********************************************************************************/
        [HttpPost]
        [Route("Login")]
        // http://localhost:50414/account/Login
        /*
             *  
            Content-Type: application/json; charset=utf-8

          {
             
            "Email":"sweif49@gmail.com",
            "Password":"123+Aa",
            "RemmberMe":true
} 
             */
        public async Task<IActionResult> login(LoginViewModel model)

        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        return Unauthorized("please check your email before ");
                    }
                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RemmberMe, true);
                    if (result.Succeeded)
                    {
                        var role = await userManager.GetRolesAsync(user);
                        //  await addCookie(user.UserName,user.Id, "Admin", model.RemmberMe);
                        var claims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        //     new Claim(ClaimTypes.Role,"Admin")

                        };
                        if (role != null)
                        {
                            foreach (string r in role)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, r));
                            }

                        }
                        var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mohammedmohammedsweif"));
                        var token = new JwtSecurityToken
                        (
                            issuer: "http://oec.com",
                            audience: "http://oec.com",
                            expires: DateTime.UtcNow.AddHours(1)
                            , claims: claims,
                            signingCredentials: new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
                        );


                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                                expiration = token.ValidTo,
                                role = role,
                                username = user.UserName,
                                id=user.Id
                            }
                            );
                    }
                    else if (result.IsLockedOut)
                    {
                        return Unauthorized("you can try after one minute");
                    }
                    else
                    {
                        return Unauthorized("email or password is not correct");
                    }
                }
                else
                {
                    return NotFound("sorry it is not found");
                }
            }
            else
            {
                return NotFound("data is not valid please check your email or password");
            }

        }

        /*****************************************************/ 
         
        [HttpGet]
        [Route("startapp")]
        //http://localhost:50414/account/startapp
        public async Task<IActionResult> startapp()
        {
            await CreateAdmin();
            await CreateRolevendor();
            await CreateRoleuser();
            return Ok("the app work good");
        }

        public async Task CreateAdmin()
        {
            ApplicationUser admin = new ApplicationUser
            {
                Email = "a@a.a",
                EmailConfirmed = true,
                UserName = "Admin",
                address = " ",
                ImageUrl = " ",
                Gender = " ",
                BioInformation = " "
            };
            var result = await userManager.CreateAsync(admin, "123+Aa");
            if (result.Succeeded)
            {
                await CreateRoleAdmin(admin);
            }

        }

        public async Task CreateRoleAdmin(ApplicationUser user)
        {
            var x = await roleManager.FindByNameAsync("Admin");
            if (x == null)
            {
                IdentityRole r = new IdentityRole("Admin");
                await roleManager.CreateAsync(r);
            }
            await userManager.AddToRoleAsync(user, "Admin");
        }
        public async Task CreateRoleuser()
        {
            var x = await roleManager.FindByNameAsync("user");
            if (x == null)
            {
                IdentityRole r = new IdentityRole("user");
                var result = await roleManager.CreateAsync(r);
            }
        }
        public async Task CreateRolevendor()
        {
            var x = await roleManager.FindByNameAsync("vendor");
            if (x == null)
            {
                IdentityRole r = new IdentityRole("vendor");
                await roleManager.CreateAsync(r);
            }

        }
        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> logoutAsync()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }






        /***********************************************/
        /*   public async Task addCookie(string username, string userid, string rolename, bool remmberme)
           {
               var claim = new List<Claim>()
               {
                   new Claim(ClaimTypes.Name,username),
                   new Claim(ClaimTypes.NameIdentifier,userid),
                   new Claim(ClaimTypes.Role,rolename)

               };
               var claimidentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

               if (remmberme)
               {
                   var authproperties = new AuthenticationProperties
                   {
                       AllowRefresh = true,
                       IsPersistent = true,
                       ExpiresUtc = DateTime.UtcNow.AddDays(10)
                   };
                   await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimidentity),
                   authproperties
                  );
               }
               else
               {
                   var authproperties = new AuthenticationProperties
                   {
                       AllowRefresh = true,
                       IsPersistent = true,
                       ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                   };
                   await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimidentity),
               authproperties
              );
               }

           }*/

    }
}
