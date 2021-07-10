using HotelReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Models.Entities
{
    public class Customer : BaseEntity
    {
		public Customer()
		{
            Reservations = new HashSet<Reservation>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public ClientState ClientState { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
