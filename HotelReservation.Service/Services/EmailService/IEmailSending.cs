using SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservation.Service.Services.EmailService
{
	public interface IEmailSending
	{
		//void SendEmail(string backGroundJobType, string startTime);
		void SendEmailAsync(string To, string message, string subject, CancellationToken canCellationToken, string senderName = null, string recipientName = null);
	}
}
