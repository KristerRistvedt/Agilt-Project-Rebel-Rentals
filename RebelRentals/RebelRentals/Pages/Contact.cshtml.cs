using System;
using System.Collections.Generic;
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
        public ContactModel(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public void OnGet()
        {

        }
    }
}