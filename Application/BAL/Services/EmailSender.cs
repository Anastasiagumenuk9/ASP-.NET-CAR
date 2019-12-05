using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class EmailSender : IEmailSender
    {

        public void SendEmail(string email, string subject, string message)
        {
            var from = "Car@gmail.com";
            var pass = "C123";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;
            var mail = new MailMessage(from, email);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;

            client.SendMailAsync(mail);
        }
    }
}
