using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;

namespace RebelRentals.Pages.Support
{
    [Authorize(Roles = "Support")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            CurrentUser = _context.Users.Single(user => user.Id == CurrentUserId);
            SetShipOrder();
        }

        public List<ShipOrder> ShipOrder = new List<ShipOrder>();
        public AspNetRoleManager<IdentityUser> RoleManager { get; set; }
        public string CurrentUserId { get; set; }
        public IdentityUser CurrentUser { get; set; }
        public string UserSort { get; set; }
        public string ShipSort { get; set; }
        public string OrderSort { get; set; }

        public void OnGetAsync(string sortOrder)
        {
            UserSort = sortOrder == "user" ? "user_desc" : "user";
            ShipSort = sortOrder == "ship" ? "ship_desc" : "ship";
            OrderSort = sortOrder == "order" ? "order_desc" : "order";

            IQueryable<ShipOrder> sortedShipOrders =
                from ShipOrder
                in _context.ShipOrder
                select ShipOrder;

            switch (sortOrder)
            {
                case "user_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.Order.User.UserName);
                    break;
                case "user":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.Order.User.UserName);
                    break;
                case "ship_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.Ship.Class);
                    break;
                case "ship":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.Ship.Class);
                    break;
                case "order_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.OrderId);
                    break;
                case "order":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.OrderId);
                    break;
                default:
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.Order.User.UserName);
                    break;
            }
        }

        public void SetShipOrder()
        {
            ShipOrder = _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).ToList();
        }
    }
}
