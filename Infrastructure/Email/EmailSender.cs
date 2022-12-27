using Application.Common;
using Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings EmailSettings { get; set; }
        private readonly IConfiguration Configuration;

        public EmailSender(IOptions<EmailSettings> emailSettings, IConfiguration Configuration)
        {
            EmailSettings = emailSettings.Value;
            this.Configuration = Configuration;
        }

        public async Task<bool> SendEmail(Application.Models.Email Email)
        {
            var Client = new SendGridClient(Configuration["EmailSettings:ApiKey"]);
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
