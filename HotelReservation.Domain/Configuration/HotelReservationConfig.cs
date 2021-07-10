using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Domain.Configuration
{
	public class HotelReservationConfig
	{
		public string DATABASE_NAME { get; set; }
		public string CustomerCollectionName { get; set; }
		public string ReservationCollectionName { get; set; }
		public string RoomCollectionName { get; set; }
		public string CONNECTION_STRING { get; set; }

	}
}
