using Postal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Service.Services.HangFireService
{
	public class EmailSetting : Email
	{
		public string To { get; set; }
		public string Message { get; set; }
	}
}
