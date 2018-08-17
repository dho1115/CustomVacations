using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomVacations.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713

    public class EmailSender : IEmailSender
    {
        public string _apikey { get; set; }

        public EmailSender(string apiKey)
        {
            this._apikey = apiKey;
        }
        public Task SendEmailAsync(string email, string subject, string message) //This comes from the IEmailSender.
        {
            SendGrid.SendGridClient client = new SendGrid.SendGridClient(_apikey);

            var msg = new SendGrid.Helpers.Mail.SendGridMessage()
            {
                From = new SendGrid.Helpers.Mail.EmailAddress("admin@travelbid.com", "Travel Bid admin"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new SendGrid.Helpers.Mail.EmailAddress(email));
            msg.TrackingSettings = new SendGrid.Helpers.Mail.TrackingSettings
            {
                ClickTracking = new SendGrid.Helpers.Mail.ClickTracking { Enable = false }
            };

            return client.SendEmailAsync(msg);
        }
    }
}
