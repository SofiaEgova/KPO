using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    public static class SendEmail
    {
        static MailAddress from = new MailAddress("KursovayaRabotaKPO@gmail.com", "Курсовая работа");

        public static void SendMessage(string address, string body)
        {
            MailAddress to = new MailAddress(address);

            using (MailMessage mail = new MailMessage(from, to))
            {
                using(SmtpClient smtpClient = new SmtpClient())
                {
                    mail.Subject = "информация";
                    mail.Body = body;

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(from.Address, "Kursovaya123");

                    smtpClient.Send(mail);
                }
            }
        }
    }
}
