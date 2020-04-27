using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RebelRentals.Data;
using RebelRentals.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace RebelRentals.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCart ShoppingCart { get; set; }

        [BindProperty]
        public double? TotalCost { get; set; } = 0.0;
        public List<Ship> ListOfShipsInCart { get; set; }

        public IndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, ShoppingCart shoppingCart)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            ShoppingCart = shoppingCart;
            ListOfShipsInCart = shoppingCart.GetShoppingList();
            if(ListOfShipsInCart != null && ListOfShipsInCart.Count > 0)
            {
                foreach (var item in ListOfShipsInCart)
                {
                    if(item.Model == "You haven't added anything yet." && ListOfShipsInCart.Count > 1)
                    {
                        ListOfShipsInCart.Remove(item);
                    }
                    TotalCost = item.Price + TotalCost;
                }
            }
            else
            {
                ListOfShipsInCart = new List<Ship>()
                {
                    new Ship
                    {
                        Model = "You haven't added anything yet.",
                    }
                };
            }
        }

        // We don't need this right now.
        /*public async Task OnGetAsync()
        {
            ShoppingCart = await _context.Ship.ToListAsync();
        }*/

        public void OrderSummary()
        {
            TotalCost = 0.0;

            foreach (var item in ListOfShipsInCart)
            {
                TotalCost = item.Price + TotalCost;
            }
        }

        public async Task OnPostFinalizeOrder()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var databaseUser = _context.Users.Single(user => user.Id == userId);
            var dbShipId = _context.Ship.Select(ship => ship.Id).ToList();
            while(dbShipId.Contains(ListOfShipsInCart[0].Id))
            {
                ListOfShipsInCart[0].Id++;
            }
            var order = new Order {
                User = databaseUser,
                DateOfPurchase = DateTime.Today,
            };
            var shipOrder = new ShipOrder {
                Ship = ListOfShipsInCart[0],
                Order = order,
            };

            try
            {
                if (ModelState.IsValid)
                {
                    _context.AddRange(order, shipOrder);
                }
            }

            catch
            {
                
            }

            await SetIdentityOn();
            await _context.SaveChangesAsync();
            await SetIdentityOff();
            OnPostClearCart();
            RedirectToPage("Summary");
        }

        public async Task SetIdentityOn()
        {
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ship ON");
            await _context.SaveChangesAsync();
        }

        public async Task SetIdentityOff()
        {
            _context.Database.OpenConnection();
            _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Ship OFF");
            await _context.SaveChangesAsync();
        }

        public void OnPostClearCart()
        {
            ShoppingCart.ClearCart();
            RedirectToPage("/Index");
        }
    }
}
