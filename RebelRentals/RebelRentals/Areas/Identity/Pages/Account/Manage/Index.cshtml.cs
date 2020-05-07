using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RebelRentals;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace RebelRentals.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly APIController _apiController;

        public bool? phoneNumberAccepted;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            APIController apiController)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _apiController = apiController;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public List<Currency> CurrencyList { get; private set; }
        public bool ShowingMenu;
        private double conversionRate;

        [BindProperty]
        public Currency Currency { get; set; }
        [BindProperty]
        public string Id { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != null)
            {
                int inputPhoneNumber = 0;
                try { inputPhoneNumber = int.Parse(Input.PhoneNumber); }
                catch 
                { 
                    phoneNumberAccepted = false;
                    return Page();
                }
                phoneNumberAccepted = await _apiController.PhoneNumberValidation(inputPhoneNumber);
            }
            else { phoneNumberAccepted = false; }
            if (phoneNumberAccepted == false) { return Page(); }
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostDisplayCurrencyChangeList()
        {
            bool listExists = HttpContext.Session.TryGetValue("SessionList", out _);
            if (!listExists)
            {
                var currencyList = await _aPIController.SetCurrencyList();
                HttpContext.Session.SetString("SessionList", JsonConvert.SerializeObject(currencyList));
            }
            ShowingMenu = true;
            return Page();
        }
        public async Task<PageResult> OnPostChangeCurrency()
        {
            Currency = JsonConvert.DeserializeObject<List<Currency>>(HttpContext.Session.GetString("SessionList"))
                .Find(currency => currency.Id == Currency.Id);
            HttpContext.Session.SetString("SessionCurrency", JsonConvert.SerializeObject(Currency));
            if (Currency.Id != "SEK")
            {
                var response = await _aPIController
                    .ConvertCurrency("SEK", JsonConvert.DeserializeObject<Currency>
                    (HttpContext.Session.GetString("SessionCurrency")).Id);
                var trimmedResponse = response.Substring(11, 7).Replace('.', ',');
                conversionRate = Convert.ToDouble(trimmedResponse);
            }
            else
            {
                conversionRate = 1;
            }
            HttpContext.Session.SetString("SessionRate", JsonConvert.ToString(conversionRate));
            return Page();
        }
    }
}
