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
        private readonly RebelRentals.Data.ApplicationDbContext _context;

        public IndexModel(RebelRentals.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
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

        public void OnGetAsync()
        {
        }
        public void SetShipOrder()
        {
            ShipOrder = _context.ShipOrder
                .Include(s => s.Order)
                .Include(s => s.Ship).ToList();
        }
    }
}
