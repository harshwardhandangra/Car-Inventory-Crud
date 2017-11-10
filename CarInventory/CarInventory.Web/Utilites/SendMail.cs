using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace CarInventory.Web.Utilites
{
    public static class SendMail
    {
        public static void VerificationMailSend(string tomailaddress)
        {
            var smtpUsername = Convert.ToString(ConfigurationManager.AppSettings["smtpUsername"]);
            var smtpPassword = Convert.ToString(ConfigurationManager.AppSettings["smtpPassword"]);
            var smtpServer = Convert.ToString(ConfigurationManager.AppSettings["smtpServer"]);
            var smtpPort = Convert.ToInt32(Convert.ToString(ConfigurationManager.AppSettings["smtpPort"]));
            var enableSSL = Convert.ToBoolean(Convert.ToString(ConfigurationManager.AppSettings["enableSSL"]));
            var verificationmailSubject = Convert.ToString(ConfigurationManager.AppSettings["verificationmailSubject"]);
            var websiteurl = Convert.ToString(ConfigurationManager.AppSettings["websiteurl"]);
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpServer;
            smtpClient.Port = smtpPort;
            smtpClient.EnableSsl = enableSSL;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mailMessage = new MailMessage(smtpUsername, tomailaddress);
            var emailverificationurl = websiteurl + "user/verify?q=" + CryptoEngine.Encrypt(tomailaddress);
            mailMessage.Body = "<a href=" + emailverificationurl + " target='_blank'>Please Click Here to Verify the Email</a>";
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = verificationmailSubject;
            smtpClient.Send(mailMessage);
        }
    }
}