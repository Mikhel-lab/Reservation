using HotelReservation.Domain.Configuration;
using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Repositories.Implemetation
{
	public class DbClient : IDbClient
	{
		private readonly IMongoCollection<Customer> _customer;
		private readonly IMongoCollection<Reservation> _reservation;
		private readonly IMongoCollection<Room> _room;
		private readonly HotelReservationConfig _config;
		public DbClient(IOptions<HotelReservationConfig> configuration)
		{
			_config = configuration.Value;
			var client = new MongoClient(_config.CONNECTION_STRING);
			var database = client.GetDatabase(_config.DATABASE_NAME);
			_customer = database.GetCollection<Customer>(_config.CustomerCollectionName);
			_reservation = database.GetCollection<Reservation>(_config.ReservationCollectionName);
			_room = database.GetCollection<Room>(_config.RoomCollectionName);
		}
		public IMongoCollection<Customer> GetAllCustomerCollection() => _customer;
		public IMongoCollection<Reservation> GetAllReservationCollection() => _reservation;
		public IMongoCollection<Room> GetAllRoomCollection() => _room;
	
	}
}
