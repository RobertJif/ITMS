using System;
using System.Net.Mail;
using DevExpress.XtraEditors;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Collections;

namespace Activity.Core
{
    class MailSender
    {
        public void SendEmail(string mailSubject, string mailBody, ArrayList mailTo)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate,
                     X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                MailMessage mail = new MailMessage();
                MailAddress fromMail = new MailAddress("it.dept@bangunsaranagroup.com");

                string toMail = "";
                foreach(string address in mailTo) toMail = toMail + address + ",";
                if (mailTo.Count > 0) toMail = toMail.Substring(0, toMail.Length - 1); 

                mail.From = fromMail;
                mail.To.Add(toMail);
                mail.Subject = mailSubject;
                mail.Body = mailBody;

                SmtpClient client = new SmtpClient("mail.bangunsaranagroup.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("it.dept", "12345678");
                client.EnableSsl = true;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
