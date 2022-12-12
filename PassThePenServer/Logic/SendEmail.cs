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
        private const string _displayName = "Pass The Pen";
        private const string _body = "Your validation code is: ";
        private readonly Log _log = new Log();

        public int SendNewEmail(String to, String affair, int validationCode)
        {
            int result = 200;
            try
            {
                string from = ConfigurationManager.AppSettings.Get("Email");
                string password = ConfigurationManager.AppSettings.Get("Password");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(from , _displayName);
                mailMessage.To.Add(to);
                mailMessage.Subject = affair;
                mailMessage.Body = _body + validationCode;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (ArgumentNullException ex)
            {
                _log.Add(ex.ToString());
            }
            catch (SmtpException ex)
            {
                _log.Add(ex.ToString());
                result = 500;
            }
            return result;
        }
    }
}
