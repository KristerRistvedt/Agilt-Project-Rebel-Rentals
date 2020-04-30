using RebelRentals;
using RestClient.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AE.Net.Mail;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using System.IO;
using System.Net.Mail;
using Google.Apis.Services;
using System.Web.Helpers;
using System.Net;
using MailMessage = System.Net.Mail.MailMessage;
using RestClient.Net.Abstractions;

namespace RebelRentals
{
    public class APIController
    {
        public ApodModel Apod { get; set; }

        private readonly string supportEmail = "rebelrentalshelp@gmail.com";
        private readonly string supportEmailPassword = "AllasMamma";
        private readonly string smtpServerAddress = "smtp.gmail.com";

        public async Task<bool> ContainsProfanity(string stringToCheck)
        {
            var client = new Client(new Uri("https://www.purgomalum.com/service/containsprofanity?text=" + stringToCheck));
            var response = await client.GetAsync<bool>();
            return response;
        }

        public async Task<bool> UpdateApod()
        {
            bool updated;
            if (Apod == null)
            {
                var client = new Client(new Uri("https://apodapi.herokuapp.com/api"));
                var response = await client.GetAsync<ApodModel>();
                Apod = response;
                updated = true;
            }
            else { updated = false; }
            return updated;
        }

        internal async Task<bool> PhoneNumberValidation(int phoneNumber)
        {
            var client = new Client(new Uri("http://apilayer.net/api/validate?access_key=f994bc4c2013d3cd24fd50b8c6d1a5e6&number=" + phoneNumber + "&country_code=SE"));
            PhoneNumberValidationModel response = await client.GetAsync<PhoneNumberValidationModel>();
            bool result = response.Valid;
            return result;
        }

        public bool SendEmailToSupport(string name, string senderEmail, string message)
        {
            bool result;
            try
            {
                SmtpClient client = new SmtpClient(smtpServerAddress, 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(supportEmail, supportEmailPassword);
                MailMessage messageObject = new MailMessage();
                messageObject.To.Add(supportEmail);
                messageObject.From = new MailAddress(senderEmail);
                messageObject.Subject = $"Query by: {name} / {senderEmail}";
                messageObject.Body = message;
                client.Send(messageObject);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}