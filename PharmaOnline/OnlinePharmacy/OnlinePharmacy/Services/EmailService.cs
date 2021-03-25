using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class EmailService
    {
        private const string myEmail = "iassproiect1234@gmail.com";
        private const string myPassword = "12345Pes";

        public bool sendMailTo(string email, string title, string content)
        {
            try
            {
                var fromAddress = new MailAddress(myEmail, "IASS-PROJ");
                var toAddress = new MailAddress(email, "User");
                const string fromPassword = myPassword;
                string subject = title;
                string body = content;

               
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                smtp.UseDefaultCredentials = true;
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                return true;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}