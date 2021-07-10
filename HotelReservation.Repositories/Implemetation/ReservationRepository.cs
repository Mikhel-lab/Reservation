using HotelReservation.Domain.Configuration;
using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Exceptions;
using HotelReservation.Repositories.Interface;
using HotelReservation.Repositories.Requests;
using HotelReservation.Service.Services.EmailService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Implemetation
{
	public class ReservationRepository : IReservationRepository
	{
		private readonly IEmailSending sending;
		private readonly IMongoCollection<Reservation> _reservation;
		public ReservationRepository(IDbClient dbClient, IEmailSending emailSending)
		{
			_reservation = dbClient.GetAllReservationCollection();
			sending = emailSending;
		}
		public async Task<Reservation> BookOrReserve(ReservationRequest reservation)
		{
			var reserve = new Reservation
			{
				 CustomerId = reservation.CustomerId,
				 ReservationDate = reservation.ReservationDate,
				 Room = reservation.Room,
				 AccommodationDate = reservation.AccommodationDate,
				 Email = reservation.Email 
			};
			await _reservation.InsertOneAsync(reserve);
			sending.SendEmailAsync(reserve.Email, "Your Room Has Been Booked Successfully", "Hotel Reservation", CancellationToken.None);
			return reserve;
		}

		private async Task<Reservation> GetByIdAsync(int id)
		{
			return await _reservation.Find(c => c.CustomerId == id).FirstOrDefaultAsync();
		}
	}
}
