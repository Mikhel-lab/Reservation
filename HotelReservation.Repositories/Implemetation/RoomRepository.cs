using HotelReservation.Models.Entities;
using HotelReservation.Repositories.Interface;
using HotelReservation.Service.Services.EmailService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Repositories.Implemetation
{
	public class RoomRepository : IRoomRepository
	{
		private readonly IEmailSending sending;
		private readonly IMongoCollection<Room> _room;
		public RoomRepository(IDbClient dbClient, IEmailSending emailSending)
		{
			_room = dbClient.GetAllRoomCollection();
			sending = emailSending;
		}
		public async Task<Room> CreateAsync(Room room)
		{
			var rooms = new Room
			{
				 Price = room.Price,
				 RoomState = room.RoomState,
				 RoomType = room.RoomType
			};

			await _room.InsertOneAsync(rooms);
			//sending.SendEmailAsync(customer.Email, "R", "Email sending", CancellationToken.None);
			return rooms;

		}
	}
}
