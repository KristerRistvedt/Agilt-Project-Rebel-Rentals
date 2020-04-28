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
        private APIController apiController;

        [BindProperty]
        [Display(Name = "Name")]
        public string NameField { get; set; }
        [BindProperty]
        [Display(Name = "Email")]
        public string EmailField { get; set; }
        [BindProperty]
        [Display(Name = "Message")]
        public string Message { get; set; }
        public bool? sentMailResult;
        public string MessageField { get; set; }
        public ContactModel(APIController apiController) 
        {
            this.apiController = apiController;
        }
        public class InputModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Message { get; set; }
        }

        public void OnPostSendMailToSupport()
        {
            InputModel input = new InputModel { Name = NameField, Email = EmailField, Message = MessageField };
            sentMailResult = await apiController.SendEmailToSupport(input.Name, input.Email, input.Message);
        }
    }
}