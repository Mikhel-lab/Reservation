using HotelReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Models.Entities
{
	public class Room : BaseEntity
	{
		public  RoomType RoomType { get; set; }
		public RoomState RoomState { get; set; }
		public decimal Price { get; set; }
	}
}
