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
        public string ShipIdSort { get; set; }
        public string OrderIdSort { get; set; }
        public string CountSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ShipIdSort = sortOrder == "ship" ? "ship_desc" : "ship";
            OrderIdSort = sortOrder == "order" ? "order_desc" : "order";
            CountSort = sortOrder == "count" ? "count_desc" : "count";

            IQueryable<ShipOrder> sortedShipOrders =
                from ShipOrder
                in _context.ShipOrder
                select ShipOrder;

            switch (sortOrder)
            {
                case "count_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.Count);
                    break;
                case "count":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.Count);
                    break;
                case "ship_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.ShipId);
                    break;
                case "ship":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.ShipId);
                    break;
                case "order_desc":
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.OrderId);
                    break;
                case "order":
                    sortedShipOrders = sortedShipOrders.OrderBy(m => m.OrderId);
                    break;
                default:
                    sortedShipOrders = sortedShipOrders.OrderByDescending(m => m.OrderId);
                    break;
            }

            ShipOrder = await sortedShipOrders.AsNoTracking().ToListAsync();
        }

        public void SetShipOrder()
        {
            ShipOrder = _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).ToList();
        }
    }
}
