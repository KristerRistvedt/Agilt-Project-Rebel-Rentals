using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RebelRentals.Data;

namespace RebelRentals
{
    public class ContactModel : PageModel
    {
        private ApplicationDbContext context;

        [BindProperty]
        [Display(Name = "Name")]
        public string NameField { get; set; }
        [BindProperty]
        [Display(Name = "Email")]
        public string EmailField { get; set; }
        [BindProperty]
        [Display(Name = "Message")]
        public string MessageField { get; set; }
        public ContactModel(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public void OnGet()
        {

        }
    }
}