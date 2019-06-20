using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendMailInvitationAsync(string email, string tempPassword);
    }

    public class EmailService : IEmailService
    {
        // todo move to dependencies
        private const string HelpDeskEmail = "hdblocks.production@gmail.com";
        private const string HelpDeskName = "HD Blocks";
        private const string HelpDeskPwd = "123456Qwerty";
        
        public Task SendMailInvitationAsync(string email, string tempPassword)
        {
            MailAddress from = new MailAddress(HelpDeskEmail, HelpDeskName);
            MailAddress to = new MailAddress(email);
            MailMessage mail = new MailMessage(from, to)
            {
                Subject = "Registration in HD Blocks system", 
                Body = $@"
<h2>Registration in HD Blocks system</h2>
<h3>Your temporary password is <b>{tempPassword}</b></h3>
", 
                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(HelpDeskEmail, HelpDeskPwd), EnableSsl = true
            };
            return smtp.SendMailAsync(mail);
        }
    }
}