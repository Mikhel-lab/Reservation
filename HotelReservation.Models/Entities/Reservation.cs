using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Models.Entities
{
    public class Reservation : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime ReservationDate { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime AccommodationDate { get; set; }
        public string Email { get; set; }
    }
}
