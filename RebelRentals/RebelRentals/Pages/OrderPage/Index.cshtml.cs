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
        private readonly RebelRentals.Data.ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCart ShoppingCart { get; set; }

        [BindProperty]
        public double? TotalCost { get; set; } = 0.0;
        public List<Ship> ListOfShipsInCart { get; set; }

        public IndexModel(RebelRentals.Data.ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, ShoppingCart shoppingCart)
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

        public async Task FinalizeOrder()
        {
            
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var order = new Order();
            
            
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in ListOfShipsInCart)
                    {
                        _context.Add(item.Id);
                    }
                }
            }

            catch
            {

            }
            
            await _context.SaveChangesAsync();
            ClearCart();
            RedirectToPage("Summary");

        }

        public void ClearCart()
        {
            ShoppingCart.ClearCart();
        }
    }
}
