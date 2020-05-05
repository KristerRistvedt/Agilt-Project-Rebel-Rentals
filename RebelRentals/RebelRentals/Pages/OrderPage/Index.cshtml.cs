using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RebelRentals.Data;
using RebelRentals.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
            if (ListOfShipsInCart != null && ListOfShipsInCart.Count > 0)
            {
                foreach (var item in ListOfShipsInCart)
                {
                    if (item.Model == "You haven't added anything yet." && ListOfShipsInCart.Count > 1)
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

        public async Task<RedirectToPageResult> OnPostFinalizeOrder()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var databaseUser = _context.Users.Single(user => user.Id == userId);
            var order = new Order
            {
                User = databaseUser,
                DateOfPurchase = DateTime.Today,
            };
            var shipOrders = new List<ShipOrder>();
            foreach (var item in ListOfShipsInCart)
            {
                if(shipOrders.Any(so => so.ShipId == item.Id))
                {
                    continue;
                }
                shipOrders.Add(new ShipOrder
                {
                    Ship = _context.Ship.Attach(item).Entity,
                    ShipId = item.Id,
                    Order = order,
                    OrderId = order.Id,
                    Count = ListOfShipsInCart.Where(s => s.Id == item.Id).ToList().Count(),
                });
            }

            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in shipOrders)
                    {
                        await _context.ShipOrder.AddAsync(item);
                    }
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            await _context.SaveChangesAsync();
            ShoppingCart.OrderedShips.AddRange(shipOrders);
            // Should relocate this v
            //await OnPostClearCart();
            return RedirectToPage("Summary");
        }

        public async Task<RedirectToPageResult> OnPostClearCart()
        {
            ShoppingCart.ClearCart();
            return RedirectToPage("/Index");
        }
    }
}
