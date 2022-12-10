using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DataAccess;
using System.Configuration;

namespace Logic
{
    public class SendEmail
    {
        private const string displayName = "Pass The Pen";
        private const string body = "Your validation code is: ";

        public int SendNewEmail(String to, String affair, int validationCode)
        {
            int result = 200;
            try
            {
                string from = ConfigurationManager.AppSettings.Get("Email");
                string password = ConfigurationManager.AppSettings.Get("Password");
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from , displayName);
                mailMessage.To.Add(to);
                mailMessage.Subject = affair;
                mailMessage.Body = body + validationCode;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                String message = ex.Message;
                result = 500;
            }
            return result;
        }
    }
}
