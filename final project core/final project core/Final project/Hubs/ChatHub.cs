using Final_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Final_project.Hubs
{
    public class ChatHub:Hub
    {
        private UserManager<ApplicationUser> userManager;
        private ProjectDbcontext db;
        private readonly HttpContextAccessor httpContextAccessor;

        public ChatHub(UserManager<ApplicationUser> _userManager,ProjectDbcontext _db, HttpContextAccessor _httpContextAccessor)
        {
            httpContextAccessor = _httpContextAccessor;
            userManager = _userManager;
            db = _db;
        }
        public override Task OnConnectedAsync()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var s = Context.ConnectionId;

            Groups.AddToGroupAsync(s,"ss");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            return base.OnDisconnectedAsync(exception);
        }

        public async Task sendmessage(string s)
        {
             await Clients.All.SendAsync("receivemessage", s);
        }

       /* public async Task sendAsync()
        {
            var id = Context.ConnectionId;
            //await Clients.Group("MohamedHassan").SendAsync();
        }*/
    }
}
