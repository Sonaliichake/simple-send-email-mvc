using System.Net;
using System.Net.Mail;

namespace send_email.EmailHelper
{
    public class EmailhelperVM
    {
        public bool SendMail(string to, string subject, string message)
        {
            MailMessage mailMessage = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            mailMessage.From = new MailAddress("sonaliichake123@gmail.com");
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message;
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("sonaliichake123@gmail.com", "efyz axcs gpok pokz");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());


            }
            return false;


        }
    }
}
