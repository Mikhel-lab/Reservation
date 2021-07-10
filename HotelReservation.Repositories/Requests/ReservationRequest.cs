using HotelReservation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HotelReservation.Repositories.Requests
{
	public class ReservationRequest
	{
		[JsonIgnore]
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int RoomId { get; set; }
		public DateTime ReservationDate { get; set; }
		public DateTime AccommodationDate { get; set; }
		public string Email { get; set; }
		public Room Room { get; set; }
	}
}
