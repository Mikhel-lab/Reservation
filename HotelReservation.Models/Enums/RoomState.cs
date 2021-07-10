using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Models.Enums
{
	public enum RoomState
	{
		Free = 1,
		Occupied,
		Reserved,
		Cleaned,
		Unavailable
	}

	public enum ClientState
	{
		Registered = 1,
		BookedRoom,
		CheckIn,
		CheckOut
	}
}
