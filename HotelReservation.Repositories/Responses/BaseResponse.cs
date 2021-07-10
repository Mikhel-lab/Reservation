using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Repositories.Responses
{
	public class BaseResponse
	{
		public bool IsSuccesful { get; set; }
		public string Message { get; set; }

		public BaseResponse()
		{

		}

		public BaseResponse(string message)
		{
			Message = message;
		}
	}
}
