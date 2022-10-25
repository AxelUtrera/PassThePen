using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DataAccess;

namespace Logic
{
    public class SendEmail
    {
        public const string from = "PassThePen@outlook.com";
        public const string displayName = "Validation Code";
        public const string body = "Your validation code is: ";

        public int SendNewEmail(String to, String affair, int validationCode)
        {
            int result = 200;
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from , displayName);
                mailMessage.To.Add(to);
                mailMessage.Subject = affair;
                mailMessage.Body = body + validationCode;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, "bOnmEge89tBd56d");
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                result = 500;
            }
            return result;
        }
    }
}
