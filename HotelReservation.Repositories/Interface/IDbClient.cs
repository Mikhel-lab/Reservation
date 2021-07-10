using HotelReservation.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Repositories.Interface
{
	public interface IDbClient
	{
		
		IMongoCollection<Reservation> GetAllReservationCollection();
		IMongoCollection<Customer> GetAllCustomerCollection();
		IMongoCollection<Room> GetAllRoomCollection();
	}
}
