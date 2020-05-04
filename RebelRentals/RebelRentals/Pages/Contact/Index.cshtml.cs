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
        [Required]
        [Display(Name = "Name")]
        public string NameField { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Your Email")]
        public string EmailField { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Message")]
        public string MessageField { get; set; }
        public bool? sentMailResult;
        public string[] failReasons = new string[4];
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

        public void OnPostSendEmailToSupport()
        {
            InputModel input = new InputModel 
            { 
                Name = NameField, 
                Email = EmailField, 
                Message = MessageField 
            };
            bool validInput = InputValid(input);
            if (validInput) { sentMailResult = apiController.SendEmailToSupport(input.Name, input.Email, input.Message); }
            else { sentMailResult = false; }
            if (sentMailResult == false) { failReasons[3] = "The email could not be sent..."; }
        }

        private bool InputValid(InputModel input)
        {
            bool nameValid = false;
            bool emailValid = false;
            bool messageValid = false;
            if (input.Name != null && input.Name.Length > 0) { nameValid = true; }
            else { failReasons[0] = "Please insert your name"; }
            if (input.Email != null && input.Email.Length >= 3) { emailValid = true; }
            else { failReasons[1] = "Have you entered your full email address?"; }
            if (input.Message != null && input.Message.Length >= 5) { messageValid = true; }
            else { failReasons[2] = "Message is too short"; }
            if (nameValid && emailValid && messageValid) { return true; }
            return false;
        }
    }
}