using HotelReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HotelReservation.Repositories.Requests
{
	public class CustomerRegistrationRequest
	{
        [JsonIgnore]
		public int Id { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public ClientState ClientState { get; set; }
    }
}
