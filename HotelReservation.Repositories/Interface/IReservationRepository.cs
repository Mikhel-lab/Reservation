using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Interface
{
	public interface IReservationRepository
	{
		Task<Reservation> BookOrReserve(ReservationRequest reservation);
	}
}
