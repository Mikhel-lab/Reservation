using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservation.Service.Services.EmailService
{
	public class EmailSending : IEmailSending
	{
        private readonly string APIKey = "";
        private readonly string Host = "";
        private readonly string Caption = "";
        private readonly IConfiguration config;

        public EmailSending(IConfiguration config)
        {
            this.config = config;
            APIKey = config.GetSection("SendGrid:API_Key").Value;
            Host = config.GetSection("SendGrid:Host_Address").Value;
            Caption = config.GetSection("SendGrid:Caption_Subject").Value;
        }

       
        public void SendEmailAsync(string To, string message, string subject, CancellationToken canCellationToken, string senderName = null, string recipientName = null)
        {
            try
            {
                var client = new SendGridClient(APIKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(Host, senderName),
                    Subject = subject ?? Caption,
                };
                msg.AddContent(MimeType.Text, message);
                msg.AddTo(new EmailAddress(To, recipientName));
                var response =  client.SendEmailAsync(msg, canCellationToken).ConfigureAwait(false);

                //return response;
            }
            catch (Exception) { throw; }
        }
    }
}
