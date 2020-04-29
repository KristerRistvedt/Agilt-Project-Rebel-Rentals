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

namespace RebelRentals
{
    public class APIController
    {
        public ApodModel Apod { get; set; }

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

        public async Task<bool> SendEmailToSupport(string name, string senderEmail, string message)
        {
            var msg = new AE.Net.Mail.MailMessage
            {
                Subject = "Your Subject",
                Body = "Hello, World, from Gmail API!",
                From = new MailAddress("[you]@gmail.com")
            };
            msg.To.Add(new MailAddress("yourbuddy@gmail.com"));
            msg.ReplyTo.Add(msg.From); // Bounces without this!!
            var msgStr = new StringWriter();
            msg.Save(msgStr);

            var gmail = new GmailService();
            var result = gmail.Users.Messages.Send(new Message
            {
                Raw = Base64UrlEncode(msgStr.ToString())
            }, "me").Execute();
            Console.WriteLine("Message ID {0} sent.", result.Id);
        }

        private string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}