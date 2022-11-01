using Application.Common;
using Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings EmailSettings { get; set; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Application.Models.Email Email)
        {
            var Client = new SendGridClient(EmailSettings.ApiKey);
            var To = new EmailAddress(Email.To);
            var From = new EmailAddress
            {
                Email = EmailSettings.FromAddress,
                Name = EmailSettings.FromName
            };

            var Message = MailHelper.CreateSingleEmail(From, To, Email.Subject, Email.PlainText, Email.HtmlBody);
            var Response = await Client.SendEmailAsync(Message);

            return Response.StatusCode == System.Net.HttpStatusCode.OK || Response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }

    }
}
